using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mvc4BusinessLayer;
using Mvc4DataTransfer;
using Mvc4Helper;
using System.Configuration;

namespace Mvc4Application.Tests
{
    public partial class frmDsViewer : Form
    {
        public frmDsViewer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<EmployeeDTO> Employees = (new EmployeeBL(ConfigurationManager.ConnectionStrings["EmployeeDB"].ToString())).GetEmployees();
            dgvResults.DataSource = Employees;


        }
    }
}
