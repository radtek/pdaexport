using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DataBaseWork;
using Dialogs;
using Logic;
using Logic.PDAStruct;

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
                создатьСкриптНаБазуToolStripMenuItem.Enabled = true;
                выполнитьСкриптToolStripMenuItem.Enabled = true;
                ReadStruct();
                SetStruct();
             
            }
            catch (Exception ex)
            {
                DataBasePDA.Disconnect();
                MessageBox.Show("Соединение не установленно:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void SetStruct()
        {
            treeView1.Nodes.Clear();
            TreeNode node1 = new TreeNode("Таблицы");
            foreach (PDATable table in PDATable.tables)
            {
                node1.Nodes.Add(table.GetNode());
            }
            treeView1.Nodes.Add(node1);
            node1 = new TreeNode("Ограничения");
            foreach (PDAConstr constr in PDAConstr.constr)
            {
                node1.Nodes.Add(constr.GetNode());
            }
            treeView1.Nodes.Add(node1);
            node1 = new TreeNode("Отображения");
            foreach (PDAView view in PDAView.views)
            {
                node1.Nodes.Add(view.GetNode());
            }
            treeView1.Nodes.Add(node1);

        }

        private void разорватьСоединениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBasePDA.Disconnect();
            разорватьСоединениеToolStripMenuItem.Visible = !true;
            установитьСоединениеToolStripMenuItem.Visible = !false;
            создатьСкриптНаБазуToolStripMenuItem.Enabled = !true;
            выполнитьСкриптToolStripMenuItem.Enabled = !true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBasePDA.Disconnect();
            Close();
        }
        
        private static void ReadStruct()
        {
            QuerySelectPDA query = new QuerySelectPDA();
            query.Select(
                "select  TABLE_NAME, COLUMN_NAME, COLUMN_FLAGS, IS_NULLABLE, DATA_TYPE,  CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE from INFORMATION_SCHEMA.COLUMNS order by TABLE_NAME");
            List<DataRows> rows = query.GetRows();
            PDATable.Clear();
            foreach (DataRows row in rows)
            {
                PDATable.Add(row);
            }
            // get constrains          
            query = new QuerySelectPDA();
            query.Select(
                "select CONSTRAINT_NAME, CONSTRAINT_TYPE, TABLE_NAME  from INFORMATION_SCHEMA.TABLE_CONSTRAINTS order by TABLE_NAME");
            rows = query.GetRows();
            PDAConstr.Clear();
            foreach (DataRows row in rows)
            {
                PDAConstr.Add(row);
            }
            // отображения
            PDAView.Clear();
            PDAView.Add("INFORMATION_SCHEMA.COLUMNS");
            PDAView.Add("INFORMATION_SCHEMA.INDEXES");
            PDAView.Add("INFORMATION_SCHEMA.KEY_COLUMN_USAGE");
            PDAView.Add("INFORMATION_SCHEMA.PROVIDER_TYPES");
            PDAView.Add("INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS");
            PDAView.Add("INFORMATION_SCHEMA.TABLE_CONSTRAINTS");
            PDAView.Add("INFORMATION_SCHEMA.TABLES");
            
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeView1.SelectedNode!=null)
                if(treeView1.SelectedNode.Tag != null)
                {
                   ((IProp)treeView1.SelectedNode.Tag).MakeSQLView(ref listView3);
                   
                  
                   foreach (ListViewItem item in listView3.Items)
                    {
                        foreach (ListViewItem.ListViewSubItem o in item.SubItems)
                        {
                               PDATable.lst.Add(o.Text);
                        } 
                       
                    }
                   ((IProp)treeView1.SelectedNode.Tag).PropCreate(ref listView1);
                }
            
        }

        private void создатьСкриптНаБазуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // make script
            if (dlg_SaveScript.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dlg_SaveScript.FileName);
                Coordinator coordinator = new Coordinator();
                // add actions
                coordinator.AddAction(new ActionWriteDropScript(writer, PDATable.tables));
                coordinator.AddAction(new ActionWriteCreateTableScript(writer, PDATable.tables));
                coordinator.AddAction(new ActionWriteInsertScript(writer, PDATable.tables));
                //
                // example:coordinator.AddAction(new ActionPrepExportScripts());
                // make dialog
                dlgRunning dlg = new dlgRunning();
                dlg.Text = "Экспорт структуры";
                dlg.coordinator = coordinator;
                dlg.ShowDialog();
                writer.Close();
            }
        }

        private void выполнитьСкриптToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // run script
            if (dlg_OpenScript.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Coordinator coordinator = new Coordinator();
                // add actions
                coordinator.AddAction(new ActionRunScriptFromStream(dlg_OpenScript.FileName));
                //
                // example:coordinator.AddAction(new ActionPrepExportScripts());
                // make dialog
                dlgRunning dlg = new dlgRunning();
                dlg.Text = "Выполние";
                dlg.coordinator = coordinator;
                dlg.ShowDialog();
            }
        }
    }
}