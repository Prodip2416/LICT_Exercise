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
    public partial class frmMutiThreadingEDit : Form
    {
        public int Id;
        public frmMutiThreadingEDit()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int er = 0;
            if (txtName.Text == "")
            {
                er++;
            }
            if (txtEmail.Text == "")
            {
                er++;
            }
            if (txtContact.Text == "")
            {
                er++;
            }
            if (txtAddress.Text == "")
            {
                er++;
            }
            if (txtBalance.Text == "")
            {
                er++;
            }
            if (txtCnId.Text == "")
            {
                er++;
            }
            if (txtNote.Text == "")
            {
                er++;
            }
            //if (cmbGender.SelectedValue == null || cmbGender.SelectedItem.ToString() == "")
            //{
            //    er++;
            //}
            //if (cmbActive.SelectedValue == null || cmbActive.SelectedItem.ToString() == "")
            //{
            //    er++;
            //}
            if (cmbUserType.SelectedItem==null || cmbUserType.SelectedItem.ToString() == "")
            {
                er++;
            }

            if (er > 0)
                return;


            RoobDAL.Person p = new Person();

            p.Id = Id;
            p.Name = txtName.Text;
            p.ContactNo = txtContact.Text;
            p.Email = txtEmail.Text;
            p.Gender = Convert.ToInt32(cmbGender.SelectedValue);
            p.Balance = Convert.ToDouble(txtBalance.Text);
            p.Address = txtAddress.Text;
            p.UserType = cmbUserType.SelectedItem.ToString();
            p.Note = txtNote.Text;
            p.CnId = Convert.ToInt32(txtCnId.Text);
            p.EntryDate = dtpEntryDate.Value;
            p.Active = Convert.ToBoolean(cmbActive.SelectedValue);

            // Update using Multi-Threading...............

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(p);
                btnUpdate.Enabled = false;
                btnUpdate.Text = @"Updating...";
            }

          
        }

        private void frmMutiThreadingEDit_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            // Adding Gender Combo box item text and value......
            RoobDAL.ComboBoxValue item = new ComboBoxValue();
            item.Text = "Female";
            item.Value = 1;
            cmbGender.Items.Add(item);

            RoobDAL.ComboBoxValue item1 = new ComboBoxValue();
            item1.Text = "Male";
            item1.Value = 2;

            cmbGender.Items.Add(item1);
            cmbGender.SelectedIndex = -1;
            //Ending.....   

            // Adding Active Combo box item text and value......
            RoobDAL.ComboBoxValue item2 = new ComboBoxValue();
            item2.Text = "Yes";
            item2.Value = 1;
            cmbActive.Items.Add(item2);

            RoobDAL.ComboBoxValue item3 = new ComboBoxValue();
            item3.Text = "No";
            item3.Value = 2;

            cmbActive.Items.Add(item3);
            cmbActive.SelectedIndex = -1;
            //Ending.....   

            Person p = new Person();
            p.Id = Id;

            if (p.SelectById())
            {
                txtName.Text = p.Name;
                txtContact.Text = p.ContactNo;
                txtEmail.Text = p.Email;
                txtBalance.Text = p.Balance.ToString();
                txtCnId.Text = p.CnId.ToString();
                txtNote.Text = p.Note;
                txtAddress.Text = p.Address;
                cmbGender.SelectedValue = p.Gender;
                cmbActive.SelectedValue = p.Active;
                cmbUserType.SelectedItem = p.UserType;
                dtpEntryDate.Value = p.EntryDate;

            }
            else
            {
                MessageBox.Show(p.Error);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Person p = (Person)e.Argument;
            e.Result = p.Update();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            MessageBox.Show(@"Data Updated Sucessfully");
            btnUpdate.Enabled = true;
            btnUpdate.Text = @"Update";           

        }
    }
}
