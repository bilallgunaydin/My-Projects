using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WForm.Customer;
using WForm.Employee;
using WForm.Team_Leader;

namespace WForm.Project_Manager
{
    public partial class ProjectManager : Form
    {
        public ProjectManager()
        {
            InitializeComponent();
        }

        private void ProjectManager_Load(object sender, EventArgs e)
        {

        }

        private void yeniProjeOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectCreateForm create = new ProjectCreateForm();
            create.Show();
            create.MdiParent = this;
            this.Size = create.Size;
            create.WindowState = FormWindowState.Maximized;
        }

        private void projeleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectListForm list = new ProjectListForm();
            list.Show();
            list.MdiParent = this;
            
            this.Size = new Size(1006, 552);
            list.WindowState = FormWindowState.Maximized;
        }

        private void müşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerAddForm customerAdd = new CustomerAddForm();
            customerAdd.Show();
            customerAdd.MdiParent = this;
            this.Size = new Size(318, 445);
            customerAdd.WindowState = FormWindowState.Maximized;

        }

        private void müşteriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerListForm customerList = new CustomerListForm();
            customerList.Show();
            customerList.MdiParent = this;
            this.Size = new Size(763, 607);
            customerList.WindowState = FormWindowState.Maximized;
        }

        private void çalışanEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeAddForm employee = new EmployeeAddForm();
            employee.Show();
            employee.MdiParent = this;
            this.Size = new Size(354, 380);
            employee.WindowState = FormWindowState.Maximized;
        }

        private void çalışanlarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EmployeeListForm emp = new EmployeeListForm();
            emp.Show();
            emp.MdiParent = this;
            this.Size = new Size(664, 484);
            emp.WindowState = FormWindowState.Maximized;
        }

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pmTaskListForm task = new pmTaskListForm();
            task.Show();
            task.MdiParent = this;
            this.Size = task.Size;
            task.WindowState = FormWindowState.Maximized;
            task.Text = "Project Manager";
        }

        private void projeyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectEmployeeAddForm proempAdd = new ProjectEmployeeAddForm();
            proempAdd.Show();
            proempAdd.MdiParent = this;
            this.Size = proempAdd.Size;
            proempAdd.WindowState = FormWindowState.Maximized;
        }
    }
}
