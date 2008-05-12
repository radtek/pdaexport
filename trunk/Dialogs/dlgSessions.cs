using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataBaseWork;

namespace Dialogs
{
    public partial class dlgSessions : Form
    {
        public dlgSessions()
        {
            InitializeComponent();
            button1_Click(new object(), new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuerySelectOracle q=new QuerySelectOracle();
            q.Select("select username, status, program, machine from gv$session where username is not null");
            List<DataRows> rows = q.GetRows();
            listView1.Items.Clear();
            foreach (DataRows row in rows)
            {
                //listView1.Items.Add("Имя пользователя : " + row.FieldByName("username") + ";   Статус : " + row.FieldByName("status") + ";   Программа : " + row.FieldByName("program") + ";   Компьютер :  " + row.FieldByName("machine"));
                ListViewItem item = new ListViewItem(row.FieldByName("username"));
                item.SubItems.Add(row.FieldByName("status"));
                item.SubItems.Add(row.FieldByName("program"));
                item.SubItems.Add(row.FieldByName("machine"));
                listView1.Items.Add(item);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 1)
               button2.DialogResult=MessageBox.Show("Все соединения с базой будут принудительно разорваны. Продолжить?", "Warning", MessageBoxButtons.OKCancel);
        }
    }
}