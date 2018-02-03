using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDLAspFirstProject
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList ddlCountry = (DropDownList)DetailsView1.FindControl("ddlCountry");
                ddlCountry.Items.Insert(0,new ListItem("Select","0"));

                DropDownList ddlHead = (DropDownList)DetailsView1.FindControl("ddlHead");
                ddlHead.Items.Insert(0, new ListItem("Select", "0"));
            }

        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCity = (DropDownList)DetailsView1.FindControl("ddlCity");

            DAL.City city= new DAL.City();
            city.CountryId = Convert.ToInt32(((DropDownList) DetailsView1.FindControl("ddlCountry")).SelectedValue);

            ddlCity.DataSource=city.SelectCountry().Tables[0];
            ddlCity.DataTextField = "name";
            ddlCity.DataValueField = "id";
            ddlCity.DataBind();

            ddlCity.Items.Insert(0,new ListItem("Select", "0"));

        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            e.Values["cityId"]= ((DropDownList)DetailsView1.FindControl("ddlCity")).SelectedValue;
        }
        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertEventArgs e)
        {
           Response.Redirect("registerSuccess.aspx?email="+e.Values["Email"].ToString());
        }
    }
}