using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySweetCRUDApplication.DAL;

namespace MySweetCRUDApplication.Presentation
{
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Size;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmStudentNew studentNew = new frmStudentNew();
            studentNew.ShowDialog();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            DAL.Student student = new Student();
            var ds = student.Select();
            if (ds == null)
                return;
            gvStudent.DataSource = ds.Tables[0];
            this.Cursor = Cursors.Default;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvStudent.SelectedRows.Count <= 0)
                return;
            frmStudentEdit studentEdit = new frmStudentEdit();
            studentEdit.id = Convert.ToInt32(gvStudent.SelectedRows[0].Cells["colId"].Value);
            studentEdit.ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvStudent.SelectedRows.Count <= 0)
                return;

            DialogResult dr = MessageBox.Show("R U Sure?", "Delete Confirmation", MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.Student student = new Student();
            student.Id = Convert.ToInt32(gvStudent.SelectedRows[0].Cells["colId"].Value);

            if (student.Delete())
            {
                MessageBox.Show("Data deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(student.Error);
            }
        }
    }
}
