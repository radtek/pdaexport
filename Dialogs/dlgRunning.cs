using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Logic;
using Loging;

namespace Dialogs
{
    public partial class dlgRunning : Form
    {
        public dlgRunning()
        {
            InitializeComponent();
        }
        public Coordinator coordinator;

        private void dlgRunning_Shown(object sender, EventArgs e)
        {
            // настройка на прослушивание координатора
            coordinator.OnExecute += new Coordinator.ExecuteDelegate(coordinator_OnExecute);
            coordinator.OnEndAction += new Coordinator.ExecutionActionFinishDelegate(coordinator_OnEndAction);
            // получение списка работ
            string[] list = coordinator.GetActions();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(list);
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
            Loging.Loging.StartLog();
            coordinator.Run();
            Loging.Loging.EndLog();
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;           
        }

        void coordinator_OnEndAction(Coordinator c, Coordinator.ExecutionActionFinishDelegateArgs args)
        {
            /*
            if (!args.Last)
                listBox1.SelectedIndex++;
            else
            {
                MessageBox.Show(Text + " завершен");
            }*/
        }

        void coordinator_OnExecute(Coordinator c, Coordinator.ExecuteDelegateArgs args)
        {
           /* if (progressBar1.Value > args.Maximum)
                progressBar1.Value = 0;
            progressBar1.Maximum = args.Maximum;
            progressBar1.Value = args.Pos;*/
        }

        private bool CanExit = false;
        private void dlgRunning_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!CanExit)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            coordinator.Cancel();
            CanExit = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CanExit = true;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Loging.Loging.ShowLog();
        }

    }
}