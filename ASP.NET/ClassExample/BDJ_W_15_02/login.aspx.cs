using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDJ_W_15_02
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = Session["msg"].ToString();
            Session["msg"] = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int er = 0;
            lblMessage.Text = "";
            //
            //
            //

            if (er > 0)
                return;

            DAL.Ledger l = new DAL.Ledger();

            l.Email = txtEmail.Text;
            l.Password = txtPassword.Text;

            if(l.Login())
            {
                //check the email is in userActive table

                Session["id"] = l.Id;
                Session["name"] = l.Name;
                Session["type"] = "A";

                if(chkRemember.Checked)
                {
                    //set cokkie for id, name, type
                }


                if(Session["rdr"].ToString() == "")
                {
                    Response.Redirect("Default.aspx");
                }
                Response.Redirect(Session["rdr"].ToString());
            }
            else
            {
                lblMessage.Text = "Invalid Login";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}