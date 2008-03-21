using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Windows.Forms;
using DataBaseWork;
using Dialogs;
using DAO.Bridges;
using Logic;

namespace Belmost2PDA
{
    public partial class MainForm : Form
    {
        public static string[] Args;
        public MainForm()
        {
            InitializeComponent();
            string s = DataBasePDA.ConnectionString; // for DEB
            ConnectionSettings.Load(Application.StartupPath + "\\" + "conninfo.xml");
            DataBasePDA.ConnectionString = s;       // for DEB
            if(Args.Length > 0 )
            {
                if (Args[0].ToUpper() == "/SETUP")
                    настройкиToolStripMenuItem.Visible = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа переноса данных для СУСМ \"Белмост\" \n  из СУБД Oracle в СУБД MSSQL Compact Edition");
        }

        private void соединениеСOracleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new dlgOracleSetup().ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void соединениеСКПКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new dlgPDASetup().ShowDialog();
        }

        private void установкаСоединениеяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // на всякий случай Disconnect
            DataBaseOracle.Disconnect();
            DataBasePDA.Disconnect();
            // содинение с Oracle
            try
            {
                DataBaseOracle.Get();
                // соединение с КПК
                DataBasePDA.Get();
            }
            catch(Exception ex)
            {
                DataBaseOracle.Disconnect();
                DataBasePDA.Disconnect();
                MessageBox.Show("Соединение не установленно:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // все ок
            установкаСоединениеяToolStripMenuItem.Enabled = false;
            экспортToolStripMenuItem1.Enabled = true;
            // load Bridges
            cbBrType.SelectedIndex = 0;
            // show
            panel1.Visible = true;
        }
        /// <summary>
        /// выбранные мосты 
        /// </summary>
        readonly List<int> SelectedID = new List<int>();
        /// <summary>
        /// кеширование изменение в дороге
        /// </summary>
        private List<RoadData> roadCash = new List<RoadData>();
        private void cbBrType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BridgesReader.BrViewMode mode = BridgesReader.BrViewMode.viewPos;
            switch(cbBrType.SelectedIndex)
            {
                case 0:
                    mode = BridgesReader.BrViewMode.viewPos;
                    break;
                case 1:
                    mode = BridgesReader.BrViewMode.viewRel;
                    break;
            }
            // get data
            BridgesReader reader = new BridgesReader();
            roadCash = reader.Load(mode);
            SetBrTree(roadCash);
            SetBrSelTree(roadCash);

        }

        /// <summary>
        /// Формирует список выбранных мостов. Включаються только
        /// мосты которые (по идентификатору)
        /// находяться в сиписке выбранных. road - основа для иерархии
        /// </summary>
        /// <param name="road">Дороги-мосты.</param>
        private void SetBrTree(IEnumerable<RoadData> road)
        {
            tvBridges.BeginUpdate();
            tvBridges.Nodes.Clear();
            foreach (RoadData roadData in road)
            {
                TreeNode node = new TreeNode(roadData.Name);
                node.Tag = -1;
                foreach (BridgeData bridgeData in roadData.Bridges)
                {
                    if (!SelectedID.Contains(bridgeData.IDBR))
                    {
                        TreeNode subnode = new TreeNode(bridgeData.Name);
                        subnode.Tag = bridgeData.IDBR;
                        node.Nodes.Add(subnode);
                    }
                }
                tvBridges.Nodes.Add(node);
            }
            tvBridges.EndUpdate();
            RemoveEmptyRD(tvBridges);
            
        }

        /// <summary>
        /// Формирует список мостов. Исключаються мосты которые (по идентификатору)
        /// находяться в сиписке выбранных
        /// </summary>
        /// <param name="road">Дороги-мосты.</param>
        private void SetBrSelTree(IEnumerable<RoadData> road)
        {
            tvSelBridges.BeginUpdate();
            tvSelBridges.Nodes.Clear();
            foreach (RoadData roadData in road)
            {
                TreeNode node = new TreeNode(roadData.Name);
                node.Tag = -1;
                foreach (BridgeData bridgeData in roadData.Bridges)
                {
                    if (SelectedID.Contains(bridgeData.IDBR))
                    {
                        TreeNode subnode = new TreeNode(bridgeData.Name);
                        subnode.Tag = bridgeData.IDBR;
                        node.Nodes.Add(subnode);
                    }
                }
                tvSelBridges.Nodes.Add(node);
            }  
            // проверка на пустые дороги
            tvSelBridges.EndUpdate();
            RemoveEmptyRD(tvSelBridges);
            
        }

        /// <summary>
        /// Removes the empty RD.
        /// </summary>
        /// <param name="bridges">Tree view.</param>
        private static void RemoveEmptyRD(TreeView bridges)
        {
            bridges.BeginUpdate();
            List<TreeNode> delNodes = new List<TreeNode>();
            foreach (TreeNode node in bridges.Nodes)
            {
                if(node.Nodes.Count==0)
                {
                    delNodes.Add(node);    
                }
            }
            foreach (TreeNode node in delNodes)
            {
                bridges.Nodes.Remove(node);
            }
            bridges.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка если выбран мост
            if((tvBridges.SelectedNode!=null)&&((int)tvBridges.SelectedNode.Tag != -1))
            {
                int ID = (int) tvBridges.SelectedNode.Tag;
                SelectedID.Add(ID);
                string RdName = GetRoadText(ID, tvBridges);
                AddRoadIfNotExsist(tvSelBridges, RdName);
                string BrName = GetBrName(ID, tvBridges);
                AddBridge(tvSelBridges, ID, RdName, BrName);
                DelBridge(tvBridges, ID);
                RemoveEmptyRD(tvBridges);

            }
        }

        private static void DelBridge(TreeView bridges, int id)
        {
            foreach (TreeNode node in bridges.Nodes)
            {
                foreach (TreeNode treeNode in node.Nodes)
                {
                    if ((int)treeNode.Tag == id)
                    {
                        node.Nodes.Remove(treeNode);
                        return;
                    }
                }
            }
        }

        private static void AddBridge(TreeView bridges, int id, string name, string brName)
        {
            // find road node
            foreach (TreeNode node in bridges.Nodes)
            {
                if(node.Text == name)
                {
                    TreeNode newnode = new TreeNode(brName);
                    newnode.Tag = id;
                    node.Nodes.Add(newnode);
                    return;
                }
            }
        }

        private static string GetBrName(int id, TreeView bridges)
        {
            foreach (TreeNode node in bridges.Nodes)
            {
                foreach (TreeNode treeNode in node.Nodes)
                {
                    if ((int)treeNode.Tag == id)
                        return treeNode.Text;
                }
            }
            return "";
        }

        private static void AddRoadIfNotExsist(TreeView bridges, string name)
        {
            bool Exist = false;
            foreach (TreeNode node in bridges.Nodes)
            {
                if (node.Text == name)
                    Exist = true;
            }
            if(!Exist)
            {
                TreeNode node = new TreeNode(name);
                node.Tag = -1;
                bridges.Nodes.Add(node);
            }
        }

        private static string GetRoadText(int id, TreeView bridges)
        {
            foreach (TreeNode node in bridges.Nodes)
            {
                foreach (TreeNode treeNode in node.Nodes)
                {
                    if ((int)treeNode.Tag == id)
                        return node.Text;
                }
            }
            return "";
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            SelectedID.Clear();
            SetBrTree(roadCash);
            SetBrSelTree(roadCash);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Проверка если выбран мост
            if ((tvSelBridges.SelectedNode != null) && ((int)tvSelBridges.SelectedNode.Tag != -1))
            {
                int ID = (int)tvSelBridges.SelectedNode.Tag;
                SelectedID.Remove(ID);
                string RdName = GetRoadText(ID, tvSelBridges);
                AddRoadIfNotExsist(tvBridges, RdName);
                string BrName = GetBrName(ID, tvSelBridges);
                AddBridge(tvBridges, ID, RdName, BrName);
                DelBridge(tvSelBridges, ID);
                RemoveEmptyRD(tvSelBridges);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // старт экспорта
            Coordinator coordinator = new Coordinator();
            // setup actions
            coordinator.AddAction(new ActionPrepExportScripts());
            coordinator.AddAction(new ActionToTempTransferScripts(SelectedID));
            coordinator.AddAction(new ActionOracleToPDATransfer());
            coordinator.AddAction(new ActionFinishExportScripts());
            coordinator.AddAction(new ActionDeploy(false));
            coordinator.AddAction(new ActionSetBrReadOnly(SelectedID));
            // make dialog
            dlgRunning dlg = new dlgRunning();
            dlg.Text = "Экспорт";
            dlg.coordinator = coordinator;
            dlg.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int count = tvBridges.Nodes.Count;
            tvBridges.BeginUpdate();
            tvSelBridges.BeginUpdate();
            progressBar1.Value = 0;
            progressBar1.Maximum = count;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
            progressBar1.Visible = true;
            for (int i = 0; i < count; i++)
            {
                //
                progressBar1.PerformStep();
                tvBridges.SelectedNode = tvBridges.Nodes[0];
                TreeNode newselectednode=tvBridges.SelectedNode;
                int newcount = tvBridges.SelectedNode.Nodes.Count;
                for (int j = 0; j < newcount;j++)
                {
                    tvBridges.SelectedNode = newselectednode.Nodes[0];
                    button1_Click(sender,e);
                    tvSelBridges.Update();
                }
            }
            progressBar1.Visible = false;
            tvBridges.EndUpdate();
            tvSelBridges.EndUpdate();
        }
    }
}