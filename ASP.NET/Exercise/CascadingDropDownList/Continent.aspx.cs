using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace CascadingDropDownList
{
    public partial class Continent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Show Continent name in First Dropdownlist and 

                DAL.Continent c= new DAL.Continent();
                ddlContinent.DataSource = c.SelectContinent().Tables[0];

                ddlContinent.DataValueField = "ContinentId";
                ddlContinent.DataTextField = "ContinentName";
                ddlContinent.DataBind();
                // Add Select One option in the Continent dropdown list
                ddlContinent.Items.Insert(0,new ListItem("Select Continent","0"));


                ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));
                ddlCity.Items.Insert(0, new ListItem("Select City", "0"));

                ddlCountry.Enabled = false;
                ddlCity.Enabled = false;
            }
        }

        protected void ddlContinent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlContinent.SelectedValue == "-1")
            {
                ddlCountry.SelectedIndex = 0;
                ddlCity.SelectedIndex = 0;
                ddlCountry.Enabled = false;
                ddlCity.Enabled = false;
            }
            else
            {
              
                ddlCountry.Enabled = true;

                DAL.Country c= new Country();
                c.ContinentId = Convert.ToInt32(ddlContinent.SelectedValue);

                ddlCountry.DataSource = c.SelectCountry().Tables[0];
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryId";
                ddlCountry.DataBind();

                ddlCountry.Items.Insert(0, new ListItem("Select Country","0"));

                ddlCity.SelectedIndex = 0;
                ddlCity.Enabled = false;
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedValue == "-1")
            {
                ddlCity.SelectedIndex = 0;
                ddlCity.Enabled = false;
            }
            else
            {
                ddlCity.Enabled = true;

                DAL.City c= new City();
                c.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);

                ddlCity.DataSource = c.SelectCity().Tables[0];
                ddlCity.DataTextField = "CityName";
                ddlCity.DataValueField = "CityId";
                ddlCity.DataBind();

                ddlCity.Items.Insert(0,new ListItem("Select City","0"));
            }
        }
    }
}