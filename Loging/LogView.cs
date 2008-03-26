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
            int j;
            j = listBox1.SelectedIndex;
            Search(textBox1.Text,j);
        }
        private void Search(string text, int i)
        {
            int index = i;
            index++;
            bool flag = false;
                    for (int k = index; k < listBox1.Items.Count; k++)
                    {
                        if(listBox1.Items[k].ToString().Contains(text))
                        {
                            flag = true;
                            listBox1.SelectedIndex = k;
                            break;
                        }
                    }
                if(flag==false)
                    {
                        if (MessageBox.Show("Достигнут конец списка. Слово не найдено. \nПродолжить поиск с начала списка?", "Message", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            listBox1.SelectedIndex = -1;
                            Search(text,0);
                        }
                    }

         }
     }
}