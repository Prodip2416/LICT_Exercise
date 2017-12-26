using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDJ_Web_Application_First
{
    public partial class CountryNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblEMessage.Text = "";
            txtName.Text = "";
            txtName.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if (txtName.Text == "")
            {
                er++;
                lblEMessage.Text = "Required";
            }
            if (er > 0)
                return;

            DAL.Country country= new DAL.Country();
            country.Name = txtName.Text;

            if (country.Insert())
            {
                btnReset_Click(null,null);
                lblMessage.Text = "Saved";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                txtName.Focus();
            }
            else
            {
                lblMessage.Text = country.Error;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

        }
    }
}