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
                    настройкиToolStripMenuItem.Visible = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        readonly List<int> SelectedID = new List<int>();
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа переноса данных для СУСМ \"Белмост\" \n  из СУБД MSSQL Compact Edition в СУБД Oracle");
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
            // show
            panel1.Visible = true;
        }
 
        private void button4_Click(object sender, EventArgs e)
        {
            // получение списка мостов
            List<BridgeData> list = new BridgesReader(true).Load();
            // старт экспорта
            Coordinator coordinator = new Coordinator();
            // setup actions
            coordinator.AddAction(new ActionDeploy(false));
            coordinator.AddAction(new ActionSwitchTriggers(false, "Выключение триггеров"));
            coordinator.AddAction(new ActionClearOracleBr(list));
            coordinator.AddAction(new ActionPDAToOracleTransfer());
            coordinator.AddAction(new ActionSwitchTriggers(true, "Включение триггеров"));
            coordinator.AddAction(new ActionFinishImportScripts());
            coordinator.AddAction(new ActionSetBrReadOnly(null, false));
            
            // make dialog
            dlgRunning dlg = new dlgRunning();
            dlg.Text = "Импорт";
            dlg.coordinator = coordinator;
            dlg.ShowDialog();
        }
    }
}