using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySweetCRUDApplication.DAL;

namespace MySweetCRUDApplication.Presentation
{
    
    public partial class frmStudentNew : Form
    {
        ErrorProvider ep= new ErrorProvider();
         int error = 0;
        public Form MyParent { get; set; }  
        public frmStudentNew()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtName.Text == "")
            {
                error++;
                ep.SetError(txtName,"Required");
            }
            if (txtEmail.Text == "")
            {
                error++;
                ep.SetError(txtEmail, "Required");
            }
            if (cmbDept.SelectedValue==null&& cmbDept.SelectedValue=="")
            {
                error++;
                ep.SetError(cmbDept, "Required");
            }
            if(error>0)
                return;

            DAL.Student student = new Student();
            student.Name = txtName.Text;
            student.Email = txtEmail.Text;
            student.Dept = Convert.ToInt32(cmbDept.SelectedValue);

            if (student.Insert())
            {
                MessageBox.Show("Data Saved");
               
                txtName.Text = "";
                txtEmail.Text = "";
                cmbDept.SelectedValue = -1;
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(student.Error);
            }

        }

        private void frmStudentNew_Load(object sender, EventArgs e)
        {
            Department department = new Department();

            cmbDept.DataSource = department.Select().Tables[0];
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "id";
            cmbDept.SelectedValue = -1;

        }
    }
}
