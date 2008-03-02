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
                DataBasePDA.Get();
            }
            catch(Exception ex)
            {
                DataBaseOracle.Disconnect();
                DataBasePDA.Disconnect();
                MessageBox.Show("���������� �� ������������:\n" + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // ����� ��������
            Coordinator coordinator = new Coordinator();
            // setup actions
            /*
            coordinator.AddAction(new ActionPrepExportScripts());
            coordinator.AddAction(new ActionToTempTransferScripts(SelectedID));
            coordinator.AddAction(new ActionOracleToPDATransfer());
            coordinator.AddAction(new ActionFinishExportScripts());
            coordinator.AddAction(new ActionDeploy());
            coordinator.AddAction(new ActionSetBrReadOnly(SelectedID));
            */
            // make dialog
            dlgRunning dlg = new dlgRunning();
            dlg.Text = "������";
            dlg.coordinator = coordinator;
            dlg.ShowDialog();
        }
    }
}