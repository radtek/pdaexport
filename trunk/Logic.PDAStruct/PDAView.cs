using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DataBaseWork;

namespace Logic.PDAStruct
{
    public class PDAView:IProp
    {
        public static List<PDAView> views  =  new List<PDAView>();
        public string Name;
        private List<DataRows> rows;

        private PDAView(string name)
        {
            Name = name;
            QuerySelectPDA query = new QuerySelectPDA();
            query.Select("select * from " + name);
            rows = query.GetRows();
        }

        public static void Clear()
        {
            views.Clear();
        }

        public static void Add(string Name)
        {
            views.Add(new PDAView(Name));
        }

        public TreeNode GetNode()
        {
            TreeNode node = new TreeNode(Name);
            node.Tag = this;
            return node;
        }

        public void MakeSQLView(ref ListView sqlView)
        {
            sqlView.Items.Clear();
            sqlView.Columns.Clear();
            if (rows.Count > 0)
            {
                foreach (DataField field in rows[0].fields)
                {
                    sqlView.Columns.Add(field.Field);
                }
                foreach (DataRows row in rows)
                {
                    ListViewItem item = null;
                    foreach (DataField field in row.fields)
                    {
                        if(item == null)
                        {
                            item = new ListViewItem(field.Value);
                        }
                        else
                        {
                            item.SubItems.Add(field.Value);
                        }
                    }
                    sqlView.Items.Add(item);
                }
            }
        }

        public void PropAdd(ref ListView propView)
        {
            if(rows.Count>0)
            {
                foreach (DataField field in rows[0].fields)
                {
                    ListViewItem item = new ListViewItem("");
                    item.SubItems.Add(field.Field);
                    propView.Items.Add(item);
                }
            }
        }

        public void PropCreate(ref ListView propView)
        {
            propView.Items.Clear();
            PropAdd(ref propView);
        }
    }
}