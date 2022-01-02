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
    public partial class TaskListForm : Form
    {
        TaskBLL _taskBLL;
        Tasks _task;
        SituaitionBLL _situaitionBLL;
        EmployeeBLL _employeeBLL;
        ProjectBLL _projectBLL;
        public TaskListForm()
        {
            InitializeComponent();
            _taskBLL = new TaskBLL();
            _task = new Tasks();
            _situaitionBLL = new SituaitionBLL();
            _employeeBLL = new EmployeeBLL();
            _projectBLL = new ProjectBLL();
        }
        private void TaskListForm_Load(object sender, EventArgs e)
        {

            GetSituaition();
            GetEmployees();

        }

        private void GetEmployees()
        {
            cmbTasksAssigned.DataSource = _employeeBLL.GetAllAccountType();
            cmbTasksAssigned.DisplayMember = "FullName";
            cmbTasksAssigned.ValueMember = "EmployeeID";
            cmbTasksAssigned.SelectedIndex = -1;
        }

        private void GetSituaition()
        {
            cmbSituaition.DataSource = _situaitionBLL.GetAll();
            cmbSituaition.DisplayMember = "Name";
            cmbSituaition.ValueMember = "SituationID";
            cmbSituaition.SelectedIndex = -1;
        }
        private void GetTask()
        {
            dgvTaskList.DataSource = _taskBLL.GetAllMyTask(Login.LoginID);
        }
        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvTaskList.SelectedRows[0].Cells[0].Value;
            _task = _taskBLL.Get(id);
            txtTaskName.Text = _task.Name;
            txtDescription.Text = _task.Description;
            txtProjectName.Text = _task.Project.Name;
            dtpStartDate.Value = _task.StartDate;
            dtpEndDate.Value = _task.EndDate;
            cmbSituaition.SelectedValue = _task.SituaitionID;
            cmbTasksAssigned.SelectedValue = _task.EmployeeID;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dgvTaskList.SelectedRows[0].Cells[0].Value;
                _task.Name = txtTaskName.Text;
                _task.Description = txtDescription.Text;
                _task.StartDate = dtpStartDate.Value;
                _task.EndDate = dtpEndDate.Value;
                if (cmbTasksAssigned.SelectedIndex != -1)
                    _task.EmployeeID = (int)cmbTasksAssigned.SelectedValue;
                _task.SituaitionID = (int)cmbSituaition.SelectedValue;
                if ((int)cmbSituaition.SelectedValue == 2 || (int)cmbSituaition.SelectedValue == 3)
                {
                    _task.isFinish = false;
                }
                bool control = _taskBLL.Update(_task);
                if (control)
                    MessageBox.Show("Güncelleme işlemi gerçekleşti", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Güncelleme işlemi sırasında Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Güncelleme işlemi sırasında Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            GetTask();
        }

        private void btnMyProjects_Click(object sender, EventArgs e)
        {
            GetTask();

        }

        private void btnCompletedProjects_Click(object sender, EventArgs e)
        {
            dgvTaskList.DataSource = _taskBLL.GetAllMyFinishProject(Login.LoginID);
        }
    }
}
