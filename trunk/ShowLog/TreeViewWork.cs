using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAO.Bridges;
using DataBaseWork;
using Constants;

namespace ShowLog
{
    public class TreeViewWork
    {
        public static void SetBrTree(TreeView tree, IEnumerable<RoadData> road, string Ord)
        {
            tree.BeginUpdate();
            tree.Nodes.Clear();
            List<int> SelectedID=new List<int>();
            switch (Ord)
            {
                case "По дате":
                    Ord = "Rundate";
                    break;
                case "По типу изменения":
                    Ord = "LogType";
                    break;
                case "По имени таблицы":
                    Ord = "TableName";
                    break;
                default:
                    Ord = "RunDate";
                    break;
            }
            foreach (RoadData roadData in road)
            {
                TreeNode node = new TreeNode(roadData.Name);
                node.Tag = -1;
                TreeNode trn = null;
                foreach (BridgeData bridgeData in roadData.Bridges)
                {
                    if (!SelectedID.Contains(bridgeData.IDBR))
                    {
                        TreeNode subnode = new TreeNode(bridgeData.Name);
                        subnode.Tag = bridgeData.IDBR + "IDBR";
                        node.Nodes.Add(subnode);
                        //AddLog here
                        List<object> lst = AddLog(bridgeData.IDBR.ToString(), Ord, true);
                        if (lst.Count > 0)
                        { subnode.ForeColor = Color.Red;
                            trn = node; } 
                        foreach (BrLog log in lst)
                        {
                            TreeNode subsubnode = new TreeNode(log.RunDate + ": " + log.LogType + ": " + log.TableDescr + "(" + log.TableName + ") ");
                            subsubnode.Tag = log.IdLog;
                            subnode.Nodes.Add(subsubnode);
                        }
                    }
                }
                tree.Nodes.Add(node);
                if(trn!=null) trn.ExpandAll();
            }
            tree.EndUpdate();
            RemoveEmptyRD(tree);
        }

        public static void RemoveEmptyRD(TreeView bridges)
        {
            bridges.BeginUpdate();
            List<TreeNode> delNodes = new List<TreeNode>();
            foreach (TreeNode node in bridges.Nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    delNodes.Add(node);
                }
            }
            foreach (TreeNode node in delNodes)
            {
                bridges.Nodes.Remove(node);
            }
            bridges.EndUpdate();
        }

        public static List<object> AddLog(string id, string Order, bool Dummy)
        {
            List<object> result = new List<object>();
            QuerySelectPDA q = new QuerySelectPDA();
            string BrLog = "Select * from BrLog where idBr=" + id + " Order by " + Order;
            string BrLogDet = "Select * from BrLogDet where idlog=" + id + " Order by IdLogDet";
            if (Dummy)
            {
                q.Select(BrLog);
                List<DataRows> lst = q.GetRows();
                foreach (DataRows rows in lst)
                {
                    BrLog log = new BrLog();
                    log.LogType = rows.FieldByName("LogType");
                    log.TableName = rows.FieldByName("TableName");
                    log.TableDescr = rows.FieldByName("TableDescr");
                    log.RunDate = rows.FieldByName("Rundate");
                    log.IdLog = rows.FieldByName("idLog");
                    result.Add(log);
                }
            }
            else
            {
                q.Select(BrLogDet);
                List<DataRows> lst = q.GetRows();
                foreach (DataRows rows in lst)
                {
                    BrLogDet log = new BrLogDet();
                    log.FieldName = rows.FieldByName("FieldName");
                    log.FieldDescr = rows.FieldByName("FieldDescr");
                    log.ValueOld = rows.FieldByName("ValueOld");
                    log.ValueNew = rows.FieldByName("ValueNew");
                    result.Add(log);
                }
            }
            return result;
        }
        public static void ListViewWork(ListView listv, List<object> lst)
        {
            foreach (BrLogDet det in lst)
            {
                ListViewItem item = new ListViewItem(det.FieldName);
                item.SubItems.Add(det.FieldDescr);
                item.SubItems.Add(det.ValueOld);
                item.SubItems.Add(det.ValueNew);
                listv.Items.Add(item);
            }
        }
        public static void DataGridWork(DataGridView grid, List<object> lst)
        {
            foreach (BrLogDet det in lst)
            {
                string[] str = new string[] { det.FieldName, det.FieldDescr, det.ValueOld, det.ValueNew};
                grid.Rows.Add(str);
            }
            ///2 method
            ///but namecolumn==prop.Name
            //grid.DataSource = lst; 

            ///3 method
            //foreach (BrLogDet det in lst)
            //{
            //    DataGridViewRow r = new DataGridViewRow();
            //    DataGridViewTextBoxCell[] c = new DataGridViewTextBoxCell[4];
            //    for (int i = 0; i < c.Length;i++ )
            //    {
            //        c[i]=new DataGridViewTextBoxCell();
            //    }
            //    c[0].Value = det.ValueNew;
            //    c[1].Value = det.ValueOld;
            //    c[2].Value = det.FieldName;
            //    c[3].Value = det.FieldDescr;
            //    r.Cells.AddRange(c);
            //    grid.Rows.Add(r);
            //}
        }
    }
}
