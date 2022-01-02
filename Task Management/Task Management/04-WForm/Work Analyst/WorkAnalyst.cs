using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WForm.Team_Leader;

namespace WForm.Work_Analyst
{
    public partial class WorkAnalyst : Form
    {
        public WorkAnalyst()
        {
            InitializeComponent();
        }

        private void listeleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WProjectListForm proList = new WProjectListForm();
            proList.Show();
            proList.MdiParent = this;
            proList.Size = this.Size;
            proList.WindowState = FormWindowState.Maximized;
            proList.Text = "Work Analyst";
        }

        private void listeleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CustomerListForm customerList = new CustomerListForm();
            customerList.Show();
            customerList.MdiParent = this;
            customerList.Size = this.Size;
            customerList.WindowState = FormWindowState.Maximized;
            customerList.Text = "Work Analyst";
        }

        private void talepFormuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerRequestForm request = new CustomerRequestForm();
            request.Show();
            request.MdiParent = this;
            request.Size = this.Size;
            request.WindowState = FormWindowState.Maximized;
            request.Text = "Work Analyst";
        }

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskListForm task = new TaskListForm();
            task.Show();
            task.MdiParent = this;
            task.Size=this.Size;
            task.WindowState=FormWindowState.Maximized;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
