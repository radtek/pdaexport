using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DAO.Bridges;
using DataBaseWork;
using Dialogs;
using Logic;

namespace PDA2Belmost
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
                    ���������ToolStripMenuItem.Visible = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
          
        }
        //readonly List<int> SelectedID = new List<int>();
        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("��������� �������� ������ ��� ���� \"�������\" \n  �� ���� MSSQL Compact Edition � ���� Oracle");
        }

        private void �����������OracleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new dlgOracleSetup().ShowDialog();
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ��������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new dlgPDASetup().ShowDialog();
        }

        private void ��������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �� ������ ������ Disconnect
            DataBaseOracle.Disconnect();
            DataBasePDA.Disconnect();
            // ��������� � Oracle
            try
            {
                DataBaseOracle.Get();
                // ���������� � ���
              //  DataBasePDA.Get();
            }
            catch(Exception ex)
            {
                DataBaseOracle.Disconnect();
                DataBasePDA.Disconnect();
                MessageBox.Show("���������� �� �����������:\n" + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ��� ��
            ��������������������ToolStripMenuItem.Enabled = false;
            �������ToolStripMenuItem1.Enabled = true;
            // show
            panel1.Visible = true;
        }
 
        private void button4_Click(object sender, EventArgs e)
        {

            // ��������� ������ ������
            //List<BridgeData> list = new BridgesReader(true).Load();
            // ����� ��������
            Coordinator coordinator = new Coordinator();
            // setup actions
            coordinator.AddAction(new ActionDeploy(true));
            coordinator.AddAction(new ActionViewLog(new dlgLog())); 
            coordinator.AddAction(new ActionViewSessions(new dlgSessions()));
            coordinator.AddAction(new ActionToggleUsersOff());
            coordinator.AddAction(new ActionSwitchTriggers(false, "���������� ���������"));
            coordinator.AddAction(new ActionClearOracleBr());
            coordinator.AddAction(new ActionPDAToOracleTransfer());
            coordinator.AddAction(new ActionSwitchTriggers(true, "��������� ���������"));
            coordinator.AddAction(new ActionFinishImportScripts());
            coordinator.AddAction(new ActionSetBrReadOnly(null, false));
            coordinator.AddAction(new ActionDoFinally());
            // make dialog
            dlgRunning dlg = new dlgRunning();
            dlg.Text = "������";
            dlg.coordinator = coordinator;
            dlg.ShowDialog();
            FinallyStack.Run(); // ����������� ������� ������ ����������� ��� �����
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}