using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginLogoutWithSession
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["type"].ToString() =="")
            {
                Session["msg"] = "You have to login to view this content";
                Session["rdr"] = "Default.aspx";
                Response.Redirect("login.aspx");
            }
        }
    }
}