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

       

 

       
    }
}