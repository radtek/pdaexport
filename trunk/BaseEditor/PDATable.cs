using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DataBaseWork;

namespace BaseEditor
{
    public class PDATable:IProp
    {
        public static List<PDATable> tables = new List<PDATable>();
        public string Name;
        public List<PDAField> fields = new List<PDAField>();
        public List<PDAConstr> Constr = new List<PDAConstr>();

        public static void Clear()
        {
            tables.Clear();
        }

        public static void Add(DataRows row)
        {
            foreach (PDATable table in tables)
            {
                if(table.Name == row.FieldByName("TABLE_NAME"))
                {
                    table.AddField(row);
                    return;
                }
            }
            PDATable newtable = new PDATable();
            newtable.Name = row.FieldByName("TABLE_NAME");
            tables.Add(newtable);
            newtable.AddField(row);
        }

        private void AddField(DataRows row)
        {
            foreach (PDAField field in fields)
            {
                if(field.Name == row.FieldByName("COLUMN_NAME"))
                    throw new Exception("Двойное поле");
            }    
            PDAField newfield = new PDAField(row);
            fields.Add(newfield);
        }

        public TreeNode GetNode()
        {
            TreeNode node = new TreeNode(Name);
            foreach (PDAField field in fields)
            {
                node.Nodes.Add(field.GetNode());
            }
            if (Constr.Count > 0)
            {
                TreeNode constrNode = new TreeNode("Ограничения");
                foreach (PDAConstr constr in Constr)
                {
                    constrNode.Nodes.Add(constr.GetNode());
                }
                node.Nodes.Add(constrNode);
            }

            node.Tag = this;
            return node;
        }

        public void MakeSQLView(ref ListView sqlView)
        {
            sqlView.Items.Clear();
            sqlView.Columns.Clear();
            foreach (PDAField field in fields)
            {
                sqlView.Columns.Add(field.Name);
            }
            QuerySelectPDA query = new QuerySelectPDA();
            query.Select("select * from " + Name);
            List<DataRows> rows = query.GetRows();
            foreach (DataRows row in rows)
            {
                ListViewItem item = null;
                foreach (PDAField field in fields)
                {
                    if (item == null)
                        item = new ListViewItem(row.FieldByNameDef(field.Name, ""));
                    else
                        item.SubItems.Add(row.FieldByNameDef(field.Name, ""));
                }
                sqlView.Items.Add(item);
            }
        }

        public void PropAdd(ref ListView propView)
        {
            // do nothing
        }

        public void PropCreate(ref ListView propView)
        {
            propView.Items.Clear();
            foreach (PDAField field in fields)
            {
                field.PropAdd(ref propView);
            }
        }
    }
}
