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
                MessageBox.Show("���������� �����������");
            }
                
            catch (SqlCeException ex)
            {
                MessageBox.Show("���������� �� �����������:\n" + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("���������� � ��� �����������");
                }
                while(!rapi.DevicePresent)
                {
                    MessageBox.Show("���������� ������������ ��� ��������� ActiveSync.",
                    "No Device Present");
                     rapi.Connect();
                }
           }

            catch (Exception ex)
            {
                MessageBox.Show("������ �����������" + " - " + ex.Message,
                "Connection Error");
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (cmbCopyDirection.Text)
            {
                case "":
                    MessageBox.Show("�� ������ ������� ����������� �����������.",
                      "No Destination Selected");
                    break;
                case "� �������� �� ���":
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string name = openFileDialog1.FileName;
                        CopySource.Text = name;
                        CopyDestination.Text = "\\My Documents" +
                                                  name.Substring(name.LastIndexOf("\\"), name.Length - name.LastIndexOf("\\"));
                    }
                    break;
                case "� ��� �� �������":
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
                    MessageBox.Show("�� ������ ������� ����-�������� � ����-����������.",
                      "Missing File Information");
                }
                else
                {
                    switch (cmbCopyDirection.Text)
                    {
                        case "":
                            MessageBox.Show("�� ������ ������� ����������� ����� ������������.",
                              "No Destination Selected");
                            break;
                        case "� �������� �� ���":
                            rapi.CopyFileToDevice(CopySource.Text, CopyDestination.Text,true);
                            MessageBox.Show("��� ���� ����������.", "Copy Success");
                            break;
                        case "� ��� �� �������":
                            rapi.CopyFileFromDevice(CopySource.Text, CopyDestination.Text,true);
                            MessageBox.Show("��� ���� ����������.", "Copy Success");
                            break;
                    }
                }
            }

          // Handle any errors that might occur.
            catch (Exception ex)
            {
                MessageBox.Show("������ �����������" + " - " + ex.Message,
                  "Copy Error");
            }

        }
        }
    }
