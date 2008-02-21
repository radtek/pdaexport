using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataBaseWork;

namespace Dialogs
{
    public partial class dlgOracleSetup : Form
    {
        public dlgOracleSetup()
        {
            InitializeComponent();
            textBox1.Text = ConnectionSettings.GetSettings().OracleConnectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // set setings and save
            ConnectionSettings.GetSettings().OracleConnectionString = textBox1.Text;
            ConnectionSettings.Save();
            ConnectionSettings.Setup();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // save old connstring
            string save = ConnectionSettings.GetSettings().OracleConnectionString;
            ConnectionSettings.GetSettings().OracleConnectionString = textBox1.Text;
            ConnectionSettings.Setup();
            // test
            DataBaseOracle.Disconnect();
            try
            {
                DataBaseOracle.Get();
                MessageBox.Show("Соединение установлено");
            }
            catch(OracleException ex)
            {
                MessageBox.Show("Соединение не установлено:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataBaseOracle.Disconnect();
            // set old value
            ConnectionSettings.GetSettings().OracleConnectionString = save;
            ConnectionSettings.Setup();

        }
    }
}