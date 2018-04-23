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
    public partial class frmMultiThreadingEditDelete : Form
    {
        public frmMultiThreadingEditDelete()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            RoobDAL.Person p = new Person();
         
            if (!backgroundWorker1.IsBusy)
            {
               
                backgroundWorker1.RunWorkerAsync(p);
                btnShow.Enabled = false;
                btnShow.Text = @"Loading......";
            }
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

            // Delete Using Multi-Threading......
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync(p);
                btnDelete.Enabled = false;
                btnDelete.Text = @"'Deleting...";
            }
        
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmMutiThreadingEDit frmEdit= new frmMutiThreadingEDit();
            frmEdit.Id= Convert.ToInt32(dgPerson.SelectedRows[0].Cells["colId"].Value);
            frmEdit.ShowDialog();
           // btnShow.PerformClick();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Person p = (Person)e.Argument;
            e.Result = p.Select().Tables[0];
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //if (!backgroundWorker1.CancellationPending)
            //{
            //    Person p = (Person)e.UserState;
            //    dgPerson.DataSource = p.Select().Tables[0];
            //    backgroundWorker1.ReportProgress(p);
            //    lblRowCount.Text = @"Rows Process " + e.ProgressPercentage.ToString();
            //}
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {         
            dgPerson.DataSource = e.Result;
            lblMessage.Text = @"All data loaded!";
            btnShow.Enabled = true;
            btnShow.Text = @"Load Data";
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Person p = (Person) e.Argument;
            e.Result = p.Delete();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(@"Data deleted");
            btnDelete.Enabled = true;
            btnDelete.Text = @"Delete";
        }
    }
}
