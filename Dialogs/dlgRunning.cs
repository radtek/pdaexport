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
        private Thread tr;
        private delegate void DataUpdateHandler(List<int> values);
        private event DataUpdateHandler DataUpdateEvent;
        private delegate void DataUpdate(bool last);
        private event DataUpdate ListUpdateEvent;
        private delegate void ButtonUpdate();
        private event DataUpdate Buttons;
        
        public dlgRunning()
        {
            InitializeComponent();
            DataUpdateEvent+= new DataUpdateHandler(OnExecute);
            ListUpdateEvent += new DataUpdate(OnEndAction);
            Buttons+= new DataUpdate(ButtonsVisible);
            
        }
               
        public Coordinator coordinator;
        private bool _myVar1;

        public bool myVar1
        {
            get { return _myVar1; }
            set { _myVar1 = value;
                listBox1.Invoke(ListUpdateEvent, value);
                }
        }
	
        private List<int> _myVar;
        public List<int> myVar
        {
            get { return _myVar; }
            set 
            { _myVar=value;
               progressBar1.Invoke(DataUpdateEvent, value);
            }
        }
	
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
            tr = new Thread(new ThreadStart(SneakyRun));
            tr.IsBackground = true;
            tr.Start();
            
        }
        void SneakyRun()
        {
            coordinator.Run();
            Loging.Loging.EndLog();
            this.Invoke(Buttons, true);
            
        }

        void coordinator_OnEndAction(Coordinator c, Coordinator.ExecutionActionFinishDelegateArgs args)
        {
            bool value;
            value = args.Last;
            myVar1 = value;
            
        }
        void ButtonsVisible(bool Dummy)
        {
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
        }

        void OnEndAction(bool last)
        {
            if (!last)
                listBox1.SelectedIndex++;
            else
            {
                MessageBox.Show(Text + " завершен");
            }
        }

        void coordinator_OnExecute(Coordinator c, Coordinator.ExecuteDelegateArgs args)
        {
            List<int> value=new List<int>();
            //if (myVar[0] > args.Maximum)
            //     value[0] = 0;
            value.Add(args.Pos);
            value.Add(args.Maximum);
            myVar = value;
            
        }
        void OnExecute(List<int> values)
        {
            if (progressBar1.Value > values[1])
                progressBar1.Value = 0;
            progressBar1.Maximum = values[1];
            progressBar1.Value = values[0];
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
            if(tr!=null)
                tr.Abort();
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