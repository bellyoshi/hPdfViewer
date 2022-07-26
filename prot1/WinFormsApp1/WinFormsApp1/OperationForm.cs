using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class OperationForm : Form
    {
        private Form1 form1;
        
        public OperationForm(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
            
        }

        private void OperationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.Next();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form1.Back();
        }
    }
}
