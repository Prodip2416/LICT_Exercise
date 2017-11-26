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
    public partial class frmTeacher : Form
    {
        public frmTeacher()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Size;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DAL.Teacher teacher = new Teacher();
            var ds = teacher.Select();
            if (ds == null)
                return;
            gvTeacher.DataSource = ds.Tables[0];
            this.Cursor = Cursors.Default;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmTeacherNew teacherNew= new frmTeacherNew();
            teacherNew.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvTeacher.SelectedRows.Count <= 0)
                return;
            frmTeacherEdit frmTeacherNew = new frmTeacherEdit();
            frmTeacherNew.id = Convert.ToInt32(gvTeacher.SelectedRows[0].Cells["colId"].Value);
            frmTeacherNew.ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(gvTeacher.SelectedRows.Count<=0)
                return;

            DialogResult dr = MessageBox.Show("R U Sure?", "Delete Confirmation", MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.Teacher teacher = new Teacher();
            teacher.Id = Convert.ToInt32(gvTeacher.SelectedRows[0].Cells["colId"].Value);

            if (teacher.Delete())
            {
                MessageBox.Show("Data deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(teacher.Error);
            }
        }
    }
}
