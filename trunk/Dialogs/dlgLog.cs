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
            comboBox1.SelectedIndex = 1;
            comboBox2.Text = "По дате";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    mode = BridgesReader.BrViewMode.viewPos;
                    break;
                case 1:
                    mode = BridgesReader.BrViewMode.viewRel;
                    break;
            }
            // get data
            BridgesReader reader = new BridgesReader(true);
            roadCash = reader.Load(mode);
            TreeViewWork.SetBrTree(treeView1,roadCash,"");
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items.Clear();
            if (!e.Node.Tag.ToString().Contains("IDBR"))
            {
                lst = TreeViewWork.AddLog(e.Node.Tag.ToString(),"",false);
                TreeViewWork.ListViewWork(listView1, lst);
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BridgesReader reader = new BridgesReader(true);
            roadCash = reader.Load(mode);
            TreeViewWork.SetBrTree(treeView1, roadCash,comboBox2.SelectedItem.ToString());
        }
    
    }
}