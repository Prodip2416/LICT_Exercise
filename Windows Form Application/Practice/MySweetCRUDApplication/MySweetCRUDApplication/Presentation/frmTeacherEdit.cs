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
    
    public partial class frmTeacherEdit : Form
    {
        ErrorProvider ep= new ErrorProvider();
        public int id;
        public Form MyParent { get; set; }  
        public frmTeacherEdit()
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


            DAL.Teacher teacher = new Teacher();
            teacher.Id = id;
            teacher.Name = txtName.Text;
            teacher.Email = txtEmail.Text;
            teacher.Dept = Convert.ToInt32(cmbDept.SelectedValue);
            if (teacher.Update())
            {
                MessageBox.Show("Data Updated");
            }
            else
            {
                MessageBox.Show(teacher.Error);
            }

        }

        private void frmStudentNew_Load(object sender, EventArgs e)
        {
            Department d= new Department();
            cmbDept.DataSource = d.Select().Tables[0];
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "id";
            cmbDept.SelectedValue = -1;


            Teacher teacher= new Teacher();
            teacher.Id = id;
            if(teacher.SelectById())
            {
                txtName.Text = teacher.Name;
                txtEmail.Text = teacher.Email;
                cmbDept.SelectedValue = teacher.Dept;
            }

        }
    }
}
