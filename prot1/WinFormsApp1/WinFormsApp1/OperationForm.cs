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
        private ViewerForm viewerForm;
        
        public OperationForm(ViewerForm form1)
        {
            this.viewerForm = form1;
            InitializeComponent();
            
        }

        private void OperationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            viewerForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WorkPDF.ThisWorkPDF.Next();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkPDF.ThisWorkPDF.Back();
        }
    }
}
