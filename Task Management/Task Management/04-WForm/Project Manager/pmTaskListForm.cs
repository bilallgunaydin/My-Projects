using _03_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WForm.Project_Manager
{
    public partial class pmTaskListForm : Form
    {
        TaskBLL _taskBLL;
        public pmTaskListForm()
        {
            InitializeComponent();
            _taskBLL = new TaskBLL();
        }

        private void TaskListForm_Load(object sender, EventArgs e)
        {
            dgvTask.DataSource = _taskBLL.GetAllMyProject(Login.LoginID);
        }
    }
}
