using _01_Entities;
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
    public partial class ProjectListForm : Form
    {
        ProjectBLL _projectBLL;
        EmployeeBLL _employeeBLL;
        CustomerBLL _customerBLL;
        Project _project;
        public ProjectListForm()
        {
            InitializeComponent();
            _projectBLL = new ProjectBLL();
            _employeeBLL = new EmployeeBLL();
            _customerBLL = new CustomerBLL();
            _project = new Project();
        }

        private void ProjectListForm_Load(object sender, EventArgs e)
        {
            getProject();
            GetCustomer();
            GetEmployee();
            cmbEmployee.Enabled = false;
            cmbCustomer.Enabled = false;
            
        }

        private void GetEmployee()
        {
            cmbEmployee.DataSource = _employeeBLL.GetAllSelectType(1);
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "EmployeeID";
            cmbEmployee.SelectedIndex = -1;
            cmbTeamLead.DataSource = _employeeBLL.GetAllSelectType(2);
            cmbTeamLead.DisplayMember = "FullName";
            cmbTeamLead.ValueMember = "EmployeeID";
            cmbTeamLead.SelectedIndex = -1;
        }

        private void GetCustomer()
        {
            cmbCustomer.DataSource = _customerBLL.GetAll();
            cmbCustomer.DisplayMember = "ContactName";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.SelectedIndex = -1;
        }
        public void getProject()
        {
            dgvProjectList.DataSource = _projectBLL.GetAllTable();

            dgvFinishProject.DataSource = _projectBLL.GetAllFinishProject();
        }
        static int id;
        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
             id = (int)dgvProjectList.SelectedRows[0].Cells[0].Value;
            _project = _projectBLL.Get(id);
            txtProjectName.Text = _project.Name;
            txtProjectDesc.Text = _project.Description;
            cmbEmployee.SelectedValue = _project.EmployeeID;
            cmbCustomer.SelectedValue = _project.CustomerID;
            cmbTeamLead.SelectedValue = _project.TeamLeadID;
            dtpGenerate.Value = _project.GenerateDate;
            dtpDeadLine.Value = _project.DeadLine;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _project = _projectBLL.Get(id);
                _project.Name = txtProjectName.Text;
                _project.Description = txtProjectDesc.Text;
                _project.CustomerID = (int)cmbCustomer.SelectedValue;
                _project.EmployeeID = (int)cmbEmployee.SelectedValue;
                _project.TeamLeadID = (int)cmbTeamLead.SelectedValue;
                _project.GenerateDate = dtpGenerate.Value;
                _project.DeadLine = dtpDeadLine.Value;
                bool control=_projectBLL.Update(_project);
                if (control)
                    MessageBox.Show("Güncelleme gerçekleşti", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    _project = _projectBLL.Get(id);
                    MessageBox.Show("Güncelleme gerçekleşmedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception)
            {
                _project = _projectBLL.Get(id);
                MessageBox.Show("Güncelleme gerçekleşmedi","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
            
            
            getProject();
            Clear();
        }

        private void iptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
             id = (int)dgvProjectList.SelectedRows[0].Cells["ProjectID"].Value;
            _project = _projectBLL.Get(id);
            _project.IsCancel = true;
            _projectBLL.Update(_project);
            getProject();
        }

        private void btnMyProject_Click(object sender, EventArgs e)
        {
            dgvProjectList.DataSource = _projectBLL.GetAllMyProject(Login.LoginID);
            dgvFinishProject.DataSource = _projectBLL.GetAllMyFinishProject(Login.LoginID);
            Clear();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            getProject();
            Clear();
        }
        private void Clear()
        {
            txtProjectName.Text = string.Empty;
            txtProjectDesc.Text = string.Empty;
            cmbEmployee.SelectedIndex = -1;
            cmbTeamLead.SelectedIndex = -1;
            cmbCustomer.SelectedIndex = -1;
            _project = null;
        }

        private void btnFinishProject_Click(object sender, EventArgs e)
        {
            bool control = true;
            id = (int)dgvProjectList.SelectedRows[0].Cells[0].Value;

            foreach (var item in _projectBLL.GetAllProjectTask(Login.LoginID,id))
            {
                if(item.isFinish==false)
                    control=false;
            }
            if (control == false)
            {
                MessageBox.Show("Proje Sonlandırılamaz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (control)
            {
                _project = _projectBLL.Get(id);
                _project.IsFinish = true;
                _projectBLL.Update(_project);
                MessageBox.Show("Proje Tamamlandı.","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
                

        }
    }
}
