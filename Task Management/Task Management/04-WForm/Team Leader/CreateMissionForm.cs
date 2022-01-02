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

namespace WForm.Team_Leader
{
    public partial class CreateMissionForm : Form
    {
        ProjectBLL _projectBLL;
        EmployeeBLL _employeeBLL;
        Tasks _task;
        TaskBLL _taskBLL;
        Project _project;
        CustomerRequestBLL _cusRequestBLL;
        CustomerRequest cusRequest;

        public CreateMissionForm()
        {
            InitializeComponent();
            _projectBLL = new ProjectBLL();
            _employeeBLL = new EmployeeBLL();
            _task = new Tasks();
            _taskBLL = new TaskBLL();
            _project = new Project();
            _cusRequestBLL = new CustomerRequestBLL();
            cusRequest = new CustomerRequest();
        }


        private void CreateMissionForm_Load(object sender, EventArgs e)
        {
            GetProject();
            GetMissionPerson();
            GetList();


        }
        private void GetList()
        {
            try
            {
                dgvCustomerRequest.DataSource = _cusRequestBLL.GetAllSelectedProject((int)cmbProjectName.SelectedValue);
            }
            catch (Exception)
            {
            }
        }
        private void GetMissionPerson()
        {
            cmbTasksAssigned.DataSource = _employeeBLL.GetMissionEmployee();
            cmbTasksAssigned.DisplayMember = "FullName";
            cmbTasksAssigned.ValueMember = "EmployeeID";
            cmbTasksAssigned.SelectedIndex = -1;
        }

        private void GetProject()
        {

            cmbProjectName.DataSource = _projectBLL.TeamLeadProject(Login.LoginID);
            cmbProjectName.DisplayMember = "Name";
            cmbProjectName.ValueMember = "ProjectID";
            cmbProjectName.SelectedIndex = -1;
        }

        private void btnCreateMission_Click(object sender, EventArgs e)
        {
            _task.Name = txtTaskName.Text;
            _task.Description = txtDescription.Text;
            _task.ProjectID = (int)cmbProjectName.SelectedValue;
            _task.StartDate = dtpStartDate.Value;
            _task.EndDate = dtpEndDate.Value;
            _task.SituaitionID = 1;
            if (cmbTasksAssigned.SelectedIndex != -1)
                _task.EmployeeID = (int)cmbTasksAssigned.SelectedValue;
            _task.ManagerID = Login.LoginID;



            bool control = _taskBLL.Add(_task);

            if (control == true)
            {
                MessageBox.Show("İş Oluşturuldu","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                _project = _projectBLL.Get(_task.ProjectID);
                if (_project.StartDate == null)
                {
                    _project.StartDate = dtpStartDate.Value;
                    _projectBLL.Update(_project);
                }
            }
            else
                MessageBox.Show("İş Oluşturma Başarısız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            cmbProjectName.Enabled = true;

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = (int)dgvCustomerRequest.SelectedRows[0].Cells[0].Value;
            cusRequest = _cusRequestBLL.Get(id);
            _cusRequestBLL.Remove(cusRequest);
            GetList();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            int id = (int)dgvCustomerRequest.SelectedRows[0].Cells[0].Value;
            cusRequest = _cusRequestBLL.Get(id);
            txtDescription.Text = cusRequest.Description;
            cmbProjectName.Enabled = false;
            _cusRequestBLL.Remove(cusRequest);
            GetList();
        }

        private void cmbProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetList();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
