using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DataBaseWork;

namespace Logic.PDAStruct
{
    public class PDAField:IProp
    {
        public string Name;
        public bool Nullable;
        public string DataType;
        public string SLen, PLen, DLen;
        public string FullDataType;
        public bool IsPK;
        public PDAField(DataRows row)
        {
            Name = row.FieldByName("COLUMN_NAME");
            Nullable = row.FieldByName("IS_NULLABLE").ToUpper() == "TRUE";
            DataType = row.FieldByName("DATA_TYPE");
            SLen = row.FieldByNameDef("CHARACTER_MAXIMUM_LENGTH", "");
            PLen = row.FieldByNameDef("NUMERIC_PRECISION", "");
            DLen = row.FieldByNameDef("NUMERIC_SCALE", "");
            if (SLen != "")
                FullDataType = DataType + "(" + SLen + ")";
            else
            {
                if (PLen != "")
                {
                    if (DLen != "")
                        FullDataType = DataType + "(" + PLen + ", " + DLen + ")";
                    else
                        FullDataType = DataType + "(" + PLen + ")";
                }
                else
                    FullDataType = DataType;
            }
            IsPK = row.FieldByName("COLUMN_FLAGS").ToUpper() == "26";
        }
        
        public TreeNode GetNode()
        {
            TreeNode node = new TreeNode(Name);
            node.Tag = this;
            return node;
        }

        public void MakeSQLView(ref ListView sqlView)
        {
            // do nothing
        }

        public void PropAdd(ref ListView propView)
        {
            ListViewItem item = new ListViewItem(IsPK?"PK":"");
            item.SubItems.Add(Name);
            item.SubItems.Add(Nullable?"Nullable":"Not Null");
            item.SubItems.Add(FullDataType);
            propView.Items.Add(item);
        }

        public void PropCreate(ref ListView propView)
        {
            propView.Items.Clear();
            PropAdd(ref propView);
        }
    }
}