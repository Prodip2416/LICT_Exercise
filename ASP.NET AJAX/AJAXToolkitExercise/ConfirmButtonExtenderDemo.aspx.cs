using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJAXToolkitExercise
{
    public partial class ConfirmButtonExtenderDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Welcome Aushomapto, To The New World!!!!!!!!!";
            lblMessage.ForeColor = System.Drawing.Color.Green;

        }
    }
}