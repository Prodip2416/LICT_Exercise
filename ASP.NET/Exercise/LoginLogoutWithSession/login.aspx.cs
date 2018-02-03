using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace LoginLogoutWithSession
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = Session["msg"].ToString();
            lblMessage.ForeColor = System.Drawing.Color.Red;
            Session["msg"] = "";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int er = 0;
            lblMessage.Text = "";

            if (txtEmail.Text == "")
            {
                er++;
                lblMessage.Text = "Required";
            }

            if (txtPassword.Text == "")
            {
                er++;
                lblMessage.Text = "Required";
            }

            if(er>0)
                return;
           


            Ledger l= new Ledger();
            l.Email = txtEmail.Text;
            l.Password = txtPassword.Text;

            if (l.Login())
            {
                Session["id"] = l.Id;
                Session["name"] = l.Name;
                Session["type"] = "A";

                // Set Cookie....
                if (chkRemember.Checked)
                {
                    // Create the cookie object
                    HttpCookie cookie = new HttpCookie("UserDetails");
                    cookie["id"] = Session["id"].ToString();
                    cookie["name"] = Session["name"].ToString();
                    cookie["type"] = Session["type"].ToString();

                    // Cookie will be persisted for 30 days
                    cookie.Expires = DateTime.Now.AddDays(30);
                    // Add the cookie to the client machine

                      Response.Cookies.Add(cookie);
                   
                }


                // Use Redirect page.........

                if (Session["rdr"].ToString() == "")
                {
                    Response.Redirect("Default.aspx");
                }

                Response.Redirect(Session["rdr"].ToString());
            }
            else
            {
                lblMessage.Text = "Invalid Email Or Pasword";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}