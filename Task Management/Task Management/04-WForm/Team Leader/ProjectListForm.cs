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

namespace WForm.Team_Leader
{
    public partial class ProjectListForm : Form
    {
        ProjectBLL _projectBll;
        public ProjectListForm()
        {
            InitializeComponent();
            _projectBll = new ProjectBLL();
        }

        private void ProjectListForm_Load(object sender, EventArgs e)
        {
            dgvProject.DataSource = _projectBll.TeamLeadProject(Login.LoginID);
        }
    }
}
