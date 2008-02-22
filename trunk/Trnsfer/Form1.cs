using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataBaseWork;

namespace Trnsfer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1_Click(new object(), new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SQL = "select tableName from Transfer2PDA";
            QuerySelectPDA query=new QuerySelectPDA();
            query.Select(SQL);
            List<DataRows> rows = query.GetRows();
            PDATables.Items.Clear();
        
            foreach (DataRows row in rows)
            {
                PDATables.Items.Add(row.FieldByName("tableName"));
            }

            SQL = "select distinct Table_Name from user_tables";
            QuerySelectOracle Oraquery=new QuerySelectOracle();
            Oraquery.Select(SQL);
            rows = Oraquery.GetRows();
            OraTables.Items.Clear();
            foreach (DataRows row in rows)
            {
                if (!PDATables.Items.Contains(row.FieldByName("Table_Name"))) 
                OraTables.Items.Add(row.FieldByName("Table_Name"));
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OraTables.SelectedItem != null)
            {
                string idquery = "select MAX(idTransferTable) as ID from Transfer2PDA";
                QuerySelectPDA query = new QuerySelectPDA();
                query.Select(idquery);
                List<DataRows> rows = query.GetRows();
                int id;
                try
                {
                    id = Convert.ToInt32(rows[0].FieldByName("ID")) + 1;
                }
                catch(FormatException)
                {
                    id = 1;
                }
                idquery = "select MAX(idQrySelect) as ID from QrySelect";
                
                query.Select(idquery);
                 rows = query.GetRows();
                int idSelectBM;
                try 
                {
                    idSelectBM = Convert.ToInt32(rows[0].FieldByName("ID")) + 1;
                }
                catch(FormatException)
                {
                    idSelectBM = 1;
                }
                int idSelectPDA = idSelectBM + 1;

                idquery = "select MAX(idQryDelete) as ID from QryDelete";
                query.Select(idquery);
                rows = query.GetRows();
                int idDelete;
                try
                {
                     idDelete = Convert.ToInt32(rows[0].FieldByName("ID")) + 1;
                }
                catch(FormatException)
                {
                    idDelete = 1;
                }

                idquery = "select MAX(idQryClear) as ID from QryClear";
                query.Select(idquery);
                rows = query.GetRows();
                int idClear;
                try
                {
                     idClear = Convert.ToInt32(rows[0].FieldByName("ID")) + 1;
                }
                catch(FormatException)
                {
                    idClear = 1;   
                }

                idquery = "select MAX(idQryInsert) as ID from QryInsert";
                query.Select(idquery);
                rows = query.GetRows();
                int idInsert;
                try
                {
                    idInsert = Convert.ToInt32(rows[0].FieldByName("ID")) + 1;
                }
                catch(FormatException)
                {
                    idInsert = 1;
                }

                QueryExecPDA qry = new QueryExecPDA();
                string SQL = "insert into Transfer2PDA values ({0},'{1}',{2},{3},{4},{5},{6},null,null,null,null)";
                qry.Execute(String.Format(SQL, id,OraTables.SelectedItem,idSelectBM,idSelectPDA,idDelete,idClear,idInsert));
                SQL = "insert into QrySelect values ({0},null)";
                qry.Execute(String.Format(SQL, idSelectBM));
                SQL = "insert into QrySelect values ({0},null)";
                qry.Execute(String.Format(SQL, idSelectPDA));
                SQL = "insert into QryDelete values ({0},null)";
                qry.Execute(String.Format(SQL, idDelete));
                SQL = "insert into QryClear values ({0},null)";
                qry.Execute(String.Format(SQL, idClear));
                SQL = "insert into QryInsert values ({0},null)";
                qry.Execute(String.Format(SQL, idInsert));
                PDAFields.Items.Clear();
                OraFields.Items.Clear();
                button1_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PDATables.SelectedItem != null)
            {
                string SQL = "select * from Transfer2PDA where tableName='{0}'";
                QuerySelectPDA query = new QuerySelectPDA();
                query.Select(String.Format(SQL, PDATables.SelectedItem));
                List<DataRows> rows = query.GetRows();
                QueryExecPDA qry = new QueryExecPDA();

                SQL = "delete from QrySelect where idQrySelect={1}";
                qry.Execute(string.Format(SQL, SelectText.Text, rows[0].FieldByName("idQrySelectBM")));

                SQL = "delete from QrySelect where idQrySelect={1}";
                qry.Execute(string.Format(SQL, SelectPDAText.Text, rows[0].FieldByName("idQrySelectPDA")));

                SQL = "delete from QryDelete  where idQryDelete={1}";
                qry.Execute(string.Format(SQL, DeleteText.Text, rows[0].FieldByName("idQryDelete")));

                SQL = "delete from QryClear where idQryClear={1}";
                qry.Execute(string.Format(SQL, ClearText.Text, rows[0].FieldByName("idQryClear")));

                SQL = "delete from  QryInsert  where idQryinsert={1}";
                qry.Execute(string.Format(SQL, ClearText.Text, rows[0].FieldByName("idQryInsert")));

                
                SQL = "delete from Transfer2PDA where idTransferTable={0}";
                qry.Execute(String.Format(SQL, textBox1.Text));
                SQL = "delete from TransferFields where idTransferTable={0}";
                qry.Execute(String.Format(SQL, textBox1.Text));
                button1_Click(sender,e);
            }
        }

        private void PDATables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SQL = "select * from Transfer2PDA where tableName='{0}'";
            QuerySelectPDA query = new QuerySelectPDA();
            query.Select(String.Format(SQL,PDATables.SelectedItem));
            List<DataRows> rows = query.GetRows();
            if (rows.Count > 0)
            {
                if (rows[0].FieldByName("isLight") == "1") checkBox1.Checked = true;
                else checkBox1.Checked = false;
                if (rows[0].FieldByName("needExport") == "1") checkBox2.Checked = true;
                else checkBox2.Checked = false;
                textBox1.Text = rows[0].FieldByName("idTransferTable");

                SQL = "select fieldname from TransferFields where idTransferTable={0}";
                query.Select(String.Format(SQL, textBox1.Text));
                List<DataRows> rows1 = query.GetRows();
                PDAFields.Items.Clear();
                foreach (DataRows row in rows1)
                {
                    PDAFields.Items.Add(row.FieldByName("fieldname"));
                }


                /// запросы
                /// 
                SQL = "select text from QrySelect where idQrySelect={0}";
                query.Select(String.Format(SQL, rows[0].FieldByName("idQrySelectBM")));
                rows1 = query.GetRows();
                SelectText.Text = rows1[0].FieldByName("text");

                SQL = "select text from QrySelect where idQrySelect={0}";
                query.Select(String.Format(SQL, rows[0].FieldByName("idQrySelectPDA")));
                rows1 = query.GetRows();
                SelectPDAText.Text = rows1[0].FieldByName("text");

                SQL = "select text from QryDelete where idQryDelete={0}";
                query.Select(String.Format(SQL, rows[0].FieldByName("idQryDelete")));
                rows1 = query.GetRows();
                DeleteText.Text = rows1[0].FieldByName("text");

                SQL = "select text from QryClear where idQryClear={0}";
                query.Select(String.Format(SQL, rows[0].FieldByName("idQryClear")));
                rows1 = query.GetRows();
                ClearText.Text = rows1[0].FieldByName("text");

                SQL = "select text from QryInsert where idQryInsert={0}";
                query.Select(String.Format(SQL, rows[0].FieldByName("idQryInsert")));
                rows1 = query.GetRows();
                InsertText.Text = rows1[0].FieldByName("text");


            }
            else
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                PDAFields.Items.Clear();
                textBox1.Text = "";
            }

            SQL = "select Column_Name from user_tab_columns where Table_Name='{0}'";
            QuerySelectOracle OraQuery=new QuerySelectOracle();
            OraQuery.Select(String.Format(SQL, PDATables.SelectedItem));
            rows = OraQuery.GetRows();
            OraFields.Items.Clear();
            foreach (DataRows row in rows)
            {
                if (!PDAFields.Items.Contains(row.FieldByName("Column_Name")))
                OraFields.Items.Add(row.FieldByName("Column_Name"));
            }

           
            




        }

        private void OraTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SQL = "select Column_Name from user_tab_columns where Table_Name='{0}'";
            QuerySelectOracle OraQuery = new QuerySelectOracle();
            OraQuery.Select(String.Format(SQL, OraTables.SelectedItem));
            List<DataRows> rows = OraQuery.GetRows();
            FieldList.Items.Clear();
            foreach (DataRows row in rows)
            {
                FieldList.Items.Add(row.FieldByName("Column_Name"));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (PDAFields.SelectedItem != null)
            {
                QueryExecPDA qry = new QueryExecPDA();
                string SQL = "delete from TransferFields where fieldName='{0}'";
                qry.Execute(String.Format(SQL, PDAFields.SelectedItem));
                PDATables_SelectedIndexChanged(sender, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (OraFields.SelectedItem != null)
            {
                string idquery = "select MAX(idTransferField) as ID from TransferFields";
                QuerySelectPDA query = new QuerySelectPDA();
                query.Select(idquery);
                List<DataRows> rows = query.GetRows();
                int id;
                try
                {
                    id = Convert.ToInt32(rows[0].FieldByName("ID")) + 1;
                }
                catch(FormatException)
                {
                    id = 1;
                }
                QueryExecPDA qry = new QueryExecPDA();
                string SQL = "insert into TransferFields values ({0},{1},'{2}')";
                qry.Execute(String.Format(SQL, id, textBox1.Text,OraFields.SelectedItem));
                PDATables_SelectedIndexChanged(sender,e);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(PDATables.SelectedItem!=null)
            {
                int isl=0, nex=0;   
                string SQL = "update Transfer2PDA set isLight={0},  needExport={1} where idTransferTable={2}";
                if (checkBox1.Checked) isl = 1;
                if (checkBox2.Checked) nex = 1;
                QueryExecPDA qry = new QueryExecPDA();
                qry.Execute(String.Format(SQL, isl, nex, textBox1.Text));

                 SQL = "select * from Transfer2PDA where tableName='{0}'";
                QuerySelectPDA query = new QuerySelectPDA();
                query.Select(String.Format(SQL, PDATables.SelectedItem));
                List<DataRows> rows = query.GetRows();
             
                SQL = "update QrySelect set text='{0}' where idQrySelect={1}";
                qry.Execute(string.Format(SQL, SelectText.Text, rows[0].FieldByName("idQrySelectBM")));

                SQL = "update QrySelect set text='{0}' where idQrySelect={1}";
                qry.Execute(string.Format(SQL, SelectPDAText.Text, rows[0].FieldByName("idQrySelectPDA")));

                SQL = "update QryDelete set text='{0}' where idQryDelete={1}";
                qry.Execute(string.Format(SQL, DeleteText.Text, rows[0].FieldByName("idQryDelete")));

                SQL = "update QryClear set text='{0}' where idQryClear={1}";
                qry.Execute(string.Format(SQL, ClearText.Text, rows[0].FieldByName("idQryClear")));
               
                SQL = "update QryInsert set text='{0}' where idQryInsert={1}";
                qry.Execute(string.Format(SQL, InsertText.Text, rows[0].FieldByName("idQryInsert")));
                
            }
        }
    }
}