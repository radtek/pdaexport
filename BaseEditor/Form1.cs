using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataBaseWork;
using Dialogs;

namespace BaseEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConnectionSettings.Load(Application.StartupPath + "\\" + "conninfo.xml");
        }

        private void настройкаСоединенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new dlgPDASetup().ShowDialog();
        }

        private void установитьСоединениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBasePDA.Disconnect();
            // содинение с Oracle
            try
            {
                // соединение с КПК
                DataBasePDA.Get();
                разорватьСоединениеToolStripMenuItem.Visible = true;
                установитьСоединениеToolStripMenuItem.Visible = false;
            }
            catch (Exception ex)
            {
                DataBasePDA.Disconnect();
                MessageBox.Show("Соединение не установленно:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void разорватьСоединениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBasePDA.Disconnect();
            разорватьСоединениеToolStripMenuItem.Visible = !true;
            установитьСоединениеToolStripMenuItem.Visible = !false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBasePDA.Disconnect();
            Close();
        }

        private void выбрToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void ReadStruct()
        {
            // poluchit tablici
            // poluchit polja
            // poluchit tipy
            // poluchit kluchi
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // make select
            listView2.Items.Clear();
            listView2.Columns.Clear();
            if((textBox1.Text.TrimStart(' ').Length>6)&&( textBox1.Text.TrimStart(' ').Substring(0, 6).ToUpper() == "SELECT"))
            {
                QuerySelectPDA query = new QuerySelectPDA();
                if(!query.Select(textBox1.Text))
                {
                    listView2.Columns.Add("Результат", 300);
                    listView2.Items.Add(query.ErrorMsg);
                }
                else
                {
                    List<DataRows> rows = query.GetRows();
                    // make colums
                    if(rows.Count>0)
                    {
                        foreach (DataField field in rows[0].fields)
                        {
                         listView2.Columns.Add(field.Field, 100);   
                        }
                    }
                    // rows
                    foreach (DataRows row in rows)
                    {
                        bool first = true;
                        ListViewItem item = new ListViewItem();
                        foreach (DataField field in row.fields)
                        {
                            if(first)
                            {
                                first = false;
                                item = new ListViewItem(field.Value);
                            }
                            else
                            {
                                item.SubItems.Add(field.Value);  
                            }
                        }
                        listView2.Items.Add(item);
                    }
                }
            }
            else
            {
                // просто скрипт
                listView2.Columns.Add("Результат", 300);
                QueryExecPDA query = new QueryExecPDA();
                if(query.Execute(textBox1.Text))
                {
                    listView2.Items.Add("Выполнен");
                }
                else
                {
                    listView2.Items.Add(query.ErrorMsg);   
                }
            }
        }
    }
}