using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HalvaWebApplication.WebForms
{
    public partial class ValidatedFormOutput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.QueryString["name"];
            string color = Request.QueryString["favoritecolor"];
            string city = Request.QueryString["city"];

            if (name == null || color == null || city == null)
            {
                uxInvalidDataArea.Visible = true;
            }
            else
            {
                uxName.Text = name;
                uxFavoriteColor.Text = color;
                uxCity.Text = city;
            
                uxValidDataArea.Visible = true;
            }
        }
    }
}