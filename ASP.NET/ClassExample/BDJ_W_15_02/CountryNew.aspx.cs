using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDJ_W_15_02
{
    public partial class CountryNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            txtName.Text = "";
            lblEName.Text = "";
            txtName.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            int er = 0;
            if (txtName.Text == "")
            {
                er++;
                lblEName.Text = "Required";
            }

            if (er > 0)
                return;

            DAL.Country c = new DAL.Country();
            c.Name = txtName.Text;
            if (c.Insert())
            {
                btnReset_Click(null, null);
                lblMessage.Text = "Data Saved";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = c.Error;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}