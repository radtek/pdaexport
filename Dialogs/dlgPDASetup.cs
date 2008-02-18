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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //set settings and save
            ConnectionSettings.GetSettings().PDAConnectionString = textBox1.Text;
            ConnectionSettings.Save();
            ConnectionSettings.Setup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // save old connstring
            string save = ConnectionSettings.GetSettings().PDAConnectionString;
            ConnectionSettings.GetSettings().PDAConnectionString = textBox1.Text;
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
            // set old value
            ConnectionSettings.GetSettings().PDAConnectionString = save;
            ConnectionSettings.Setup();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           try 
           {
                rapi=new RAPI();
                if(rapi.DevicePresent)
                {
                    MessageBox.Show("Соединение с КПК установлено");
                }
                while(!rapi.DevicePresent)
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

        private void button4_Click(object sender, EventArgs e)
        {
            switch (cmbCopyDirection.Text)
            {
                case "":
                    MessageBox.Show("Вы должны указать направление копирования.",
                      "No Destination Selected");
                    break;
                case "С Десктопа на КПК":
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string name = openFileDialog1.FileName;
                        CopySource.Text = name;
                        CopyDestination.Text = "\\My Documents" +
                                                  name.Substring(name.LastIndexOf("\\"), name.Length - name.LastIndexOf("\\"));
                    }
                    break;
                case "С КПК на Десктоп":
                    SaveFileDialog sf = new SaveFileDialog();
                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        string name = sf.FileName;
                        CopySource.Text = name;
                        CopyDestination.Text = "\\My Documents" +
                                                  name.Substring(name.LastIndexOf("\\"), name.Length - name.LastIndexOf("\\"));
                    }
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Perform the copy.
            try
            {
                if ((CopySource.Text == "") || (CopyDestination.Text == ""))
                {
                    MessageBox.Show("Вы должны указать файл-источник и файл-назначение.",
                      "Missing File Information");
                }
                else
                {
                    switch (cmbCopyDirection.Text)
                    {
                        case "":
                            MessageBox.Show("Вы должны указать направление перед копированием.",
                              "No Destination Selected");
                            break;
                        case "С Десктопа на КПК":
                            rapi.CopyFileToDevice(CopySource.Text, CopyDestination.Text,true);
                            MessageBox.Show("Ваш файл скопирован.", "Copy Success");
                            break;
                        case "С КПК на Десктоп":
                            rapi.CopyFileFromDevice(CopySource.Text, CopyDestination.Text,true);
                            MessageBox.Show("Ваш файл скопирован.", "Copy Success");
                            break;
                    }
                }
            }

          // Handle any errors that might occur.
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения" + " - " + ex.Message,
                  "Copy Error");
            }

        }
        }
    }
