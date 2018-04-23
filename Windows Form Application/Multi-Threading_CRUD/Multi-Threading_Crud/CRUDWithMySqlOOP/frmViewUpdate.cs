using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoobDAL;

namespace CRUDWithMySqlOOP
{
    public partial class frmViewUpdate : Form
    {
        public frmViewUpdate()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            RoobDAL.Person p= new Person();

            dgPerson.DataSource = p.Select().Tables[0];
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgPerson.SelectedRows.Count <= 0)
                return;
            frmEdit Edit = new frmEdit();
            Edit.Id = Convert.ToInt32(dgPerson.SelectedRows[0].Cells["colId"].Value);
            Edit.ShowDialog();
            btnShow.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgPerson.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please Select One");
                return;
            }

            DialogResult dr = MessageBox.Show(@"R U Sure?", @"Delete Confirmation", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            RoobDAL.Person p = new Person();
            p.Id = Convert.ToInt32(dgPerson.SelectedRows[0].Cells["colId"].Value);

            if (p.Delete())
            {
                MessageBox.Show(@"Data deleted");
                btnShow.PerformClick();
            }
            else
            {
                MessageBox.Show(p.Error);
            }
        }
    }
}
