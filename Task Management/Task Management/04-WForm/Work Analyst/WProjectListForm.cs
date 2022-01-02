using _03BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WForm.Work_Analyst
{
    public partial class WProjectListForm : Form
    {
        ProjectEmployeeBLL proempBLL;
        public WProjectListForm()
        {
            InitializeComponent();
            proempBLL = new ProjectEmployeeBLL();
        }

        private void WProjectListForm_Load(object sender, EventArgs e)
        {
            dgvProject.DataSource = proempBLL.GetAllProject(Login.LoginID);
        }
    }
}
