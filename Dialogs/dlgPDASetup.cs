using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataBaseWork;
using OpenNETCF.Desktop.Communication;

namespace Dialogs
{
    public partial class dlgPDASetup : Form
    {
        private RAPI rapi;
        public dlgPDASetup()
        {
            InitializeComponent();
            textBox1.Text = ConnectionSettings.GetSettings().PDAConnectionString;
            textBox2.Text = ConnectionSettings.GetSettings().PDAConString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //set settings and save
            ConnectionSettings.GetSettings().PDAConnectionString = textBox1.Text;
            ConnectionSettings.GetSettings().PDAConString = textBox2.Text;
            ConnectionSettings.Save();
            ConnectionSettings.Setup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // save old connstrings
            string save = ConnectionSettings.GetSettings().PDAConnectionString;
            string savePDA = ConnectionSettings.GetSettings().PDAConString;
            ConnectionSettings.GetSettings().PDAConnectionString = textBox1.Text;
            ConnectionSettings.GetSettings().PDAConString = textBox2.Text;
            ConnectionSettings.Setup();
            // test
            DataBasePDA.Disconnect();
            try
            {
                DataBasePDA.Get();
                MessageBox.Show("Соединение установлено");
            }

            catch (SqlCeException ex)
            {
                MessageBox.Show("Соединение не установлено:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataBasePDA.Disconnect();
            // set old values
            ConnectionSettings.GetSettings().PDAConnectionString = save;
            ConnectionSettings.GetSettings().PDAConString = savePDA;
            ConnectionSettings.Setup();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void CopyTest_Click(object sender, EventArgs e)
        {
            // Perform the copy.
            string name = textBox1.Text;
            string CopyDestination = textBox2.Text;
            try
            {
                rapi.CopyFileToDevice(name, CopyDestination, true);
                MessageBox.Show("Ваш файл скопирован.", "Copy Success");
            }

          // Handle any errors that might occur.
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения" + " - " + ex.Message,
                  "Copy Error");
            }
        }

        private void ConnectTest_Click(object sender, EventArgs e)
        {
            try
            {
                rapi = new RAPI();
                rapi.Connect();
                if (rapi.DevicePresent)
                {
                    MessageBox.Show("Соединение с КПК установлено");
                }
                while (!rapi.DevicePresent)
                {
                    MessageBox.Show("Пожалуйста подсоедините КПК используя ActiveSync.",
                    "No Device Present");
                    rapi.Connect();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения" + " - " + ex.Message,
                "Connection Error");
                Application.Exit();
            }
        }
    }
    }
