using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WForm.Team_Leader
{
    public partial class TeamLeader : Form
    {
        public TeamLeader()
        {
            InitializeComponent();
        }

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectListForm pro = new ProjectListForm();
            pro.Show();
            pro.MdiParent = this;
        }

        private void listeleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerListForm list = new CustomerListForm();
            list.Show();
            list.MdiParent = this;
        }

        private void talepFormuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerRequestForm request = new CustomerRequestForm();
            request.Show();
            request.MdiParent = this;
        }

        private void oluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMissionForm mission = new CreateMissionForm();
            mission.Show();
            mission.MdiParent = this;
            mission.Size = this.Size;
            mission.WindowState = FormWindowState.Maximized;
        }

        private void listeleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TaskListForm task = new TaskListForm();
            task.Show();
            task.MdiParent = this;
            task.Size = this.Size;
            task.WindowState = FormWindowState.Maximized;
        }

        private void TeamLeader_Load(object sender, EventArgs e)
        {

        }
    }
}
