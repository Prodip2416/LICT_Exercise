using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDJ_W_15_02
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList ddlCountry = (DropDownList)DetailsView1.FindControl("ddlCountry");
                ddlCountry.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertEventArgs e)
        {
            Response.Redirect("registerSuccess.aspx?email=" + e.Values["email"].ToString());
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            e.Values["employeeId"] = Session["id"];
            e.Values["cityId"] = ((DropDownList)DetailsView1.FindControl("ddlCity")).SelectedValue;
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCity = (DropDownList)DetailsView1.FindControl("ddlCity");
            //ddlCity.Items.Clear();
            //ddlCity.AppendDataBoundItems = true;

            //ddlCity.Items.Add(new ListItem("Select", "0"));

            DAL.City ct = new DAL.City();
            ct.CountryId = Convert.ToInt32(((DropDownList)DetailsView1.FindControl("ddlCountry")).SelectedValue);

            ddlCity.DataSource = ct.Select().Tables[0];
            ddlCity.DataTextField = "name";
            ddlCity.DataValueField = "id";
            ddlCity.DataBind();

            ddlCity.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
}