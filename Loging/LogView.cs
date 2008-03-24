using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Loging
{
    public partial class LogView : Form
    {
        public LogView()
        {
            InitializeComponent();
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          if(e.KeyChar==27) Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string > lst=new List<string>();
            {
                
            }
            Search form = new Search();
            form.Show();
            
        }

       

 

       
    }
}