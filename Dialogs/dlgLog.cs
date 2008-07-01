using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DAO.Bridges;
using ShowLog;

namespace Dialogs
{
    public partial class dlgLog : Form
    {
        private List<RoadData> roadCash = new List<RoadData>();
        List<object> lst = new List<object>();
        BridgesReader.BrViewMode mode;
        public dlgLog()
        {
            InitializeComponent();
            comboBox2.Text = "По дате";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    mode = BridgesReader.BrViewMode.viewPosPDA;
                    break;
                case 1:
                    mode = BridgesReader.BrViewMode.ViewRelPDA;
                    break;
                default: break;
            }
            // get data
            BridgesReader reader = new BridgesReader(true);
            roadCash = reader.Load(mode);
            TreeViewWork.SetBrTree(treeView1,roadCash,"");
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //listview
            //listView1.Items.Clear();
            //if (!e.Node.Tag.ToString().Contains("IDBR"))
            //{
            //    lst = TreeViewWork.AddLog(e.Node.Tag.ToString(),"",false);
            //    TreeViewWork.ListViewWork(listView1, lst);
            //}
            dataGridView1.Rows.Clear();
            //gridview
            if(!e.Node.Tag.ToString().Contains("IDBR"))
            {
                lst = TreeViewWork.AddLog(e.Node.Tag.ToString(), "", false);
                TreeViewWork.DataGridWork(dataGridView1,lst);
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            BridgesReader reader = new BridgesReader(true);
            roadCash = reader.Load(mode);
            TreeViewWork.SetBrTree(treeView1, roadCash,comboBox2.SelectedItem.ToString());
        }

        private void dlgLog_Load(object sender, EventArgs e)
        {

        }
    
    }
}