using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDJ_W_15_02
{
    public partial class ProductImageNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            e.Values["datetime"] = DateTime.Now;
            e.Values["fileName"] = ((FileUpload)DetailsView1.FindControl("fleImage")).FileName;
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            FileUpload fle = (FileUpload)DetailsView1.FindControl("fleImage");
            fle.SaveAs(Server.MapPath("uploads/images/" + fle.FileName));

        }
    }
}