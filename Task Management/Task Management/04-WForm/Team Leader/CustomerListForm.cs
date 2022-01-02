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
    public partial class CustomerListForm : Form
    {
        CustomerBLL _customerBLL;
        public CustomerListForm()
        {
            _customerBLL = new CustomerBLL();
            InitializeComponent();
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            dgvCustomer.DataSource = _customerBLL.GetAll();
        }
    }
}
