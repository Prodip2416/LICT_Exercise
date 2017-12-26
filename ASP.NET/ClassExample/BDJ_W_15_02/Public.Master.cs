using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDJ_W_15_02
{
    public partial class Public : System.Web.UI.MasterPage
    {
        string s = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string loadMenu(int pid = 0)
        {
            DAL.Category c = new DAL.Category();
            System.Data.DataTable dt = new System.Data.DataTable();
            if (pid <= 0)
            {
                dt = c.Select(" where c.categoryId is null").Tables[0];
            }
            else
            {
                dt = c.Select(" where c.categoryId = " + pid.ToString()).Tables[0];
            }

            if (pid > 0 && dt.Rows.Count > 0)
            {
                s += "<ul>\n\r";
            }
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                s += "<li><a href=\"Shop.aspx?category=" + dt.Rows[i].ItemArray[0] + "\">" + dt.Rows[i].ItemArray[1] + "</a>";
                loadMenu(Convert.ToInt32(dt.Rows[i].ItemArray[0]));
                s += "</li>\n\r";
            }
            if (pid > 0 && dt.Rows.Count > 0)
            {
                s += "</ul>\n\r";
            }
            return s;
        }
    }
}