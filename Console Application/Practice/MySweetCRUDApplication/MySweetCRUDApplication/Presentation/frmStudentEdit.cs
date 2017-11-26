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
    
    public partial class frmStudentEdit : Form
    {
        ErrorProvider ep= new ErrorProvider();
        public int id;
        public Form MyParent { get; set; }  
        public frmStudentEdit()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int error = 0;
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
            student.Id = id;
            student.Name = txtName.Text;
            student.Email = txtEmail.Text;
            student.Dept = Convert.ToInt32(cmbDept.SelectedValue);
            if (student.Update())
            {
                MessageBox.Show("Data Updated");
            }
            else
            {
                MessageBox.Show(student.Error);
            }

        }

        private void frmStudentNew_Load(object sender, EventArgs e)
        {
            Department d= new Department();
            cmbDept.DataSource = d.Select().Tables[0];
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "id";
            cmbDept.SelectedValue = -1;


            Student s= new Student();
            s.Id = id;
            if(s.SelectById())
            {
                txtName.Text = s.Name;
                txtEmail.Text = s.Email;
                cmbDept.SelectedValue = s.Dept;
            }

        }
    }
}
