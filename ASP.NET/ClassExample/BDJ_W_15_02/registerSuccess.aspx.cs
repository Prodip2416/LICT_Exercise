using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDJ_W_15_02
{
    public partial class registerSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string MailMessage()
        {
            string s = "";
            DAL.Ledger l = new DAL.Ledger();
            l.Email = Request.QueryString["email"];

            if (l.SelectByEmail())
            {

                s += "HI, " + l.Name;
                s += "<a href=\"http://localhost:63211/active.aspx?email=" + l.Email + "\">Active</a>";
            }


            return s;
        }

        public void sendEmail()
        {
            
            
               

                //System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage("admin@mydomin.com", Request.QueryString["email"], "Account varification mail from myDomain.com", sb.ToString());
                //msg.IsBodyHtml = true;

                //System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient("mail.google.com", 971);
                //sc.UseDefaultCredentials = false;
                ////cre

                //sc.Send(msg);

               


            Response.Redirect("warning.aspx");
        }
    }
}