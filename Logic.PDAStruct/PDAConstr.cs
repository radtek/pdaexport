using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DataBaseWork;
using Logic.PDAStruct;

namespace Logic.PDAStruct
{
    public class PDAConstr:IProp
    {
        public static List<PDAConstr> constr = new List<PDAConstr>();
        public string Name;
        public string CType;
        private PDAConstr(DataRows row)
        {
            Name = row.FieldByNameDef("CONSTRAINT_NAME", "");
            CType = row.FieldByNameDef("CONSTRAINT_TYPE", "");
        }

        public static void Clear()
        {
            constr.Clear();
        }

        public static void Add(DataRows row)
        {
            PDAConstr c = new PDAConstr(row);
            foreach (PDATable table in PDATable.tables)
            {
                if (table.Name == row.FieldByNameDef("TABLE_NAME", ""))
                    table.Constr.Add(c);
            }
            constr.Add(c);
        }

        public TreeNode GetNode()
        {
            TreeNode node = new TreeNode(Name);
            node.Tag = this;
            return node;
        }

        public void MakeSQLView(ref ListView sqlView)
        {
            sqlView.Columns.Clear();
            sqlView.Items.Clear();
            sqlView.Columns.Add("Тип", 200);
            sqlView.Items.Add(CType);
        }

        public void PropAdd(ref ListView propView)
        {
            //
        }

        public void PropCreate(ref ListView propView)
        {
            propView.Clear();
        }
    }
}