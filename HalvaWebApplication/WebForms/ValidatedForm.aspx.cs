using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace HalvaWebApplication.WebForms
{
	public partial class ValidatedForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder formOutputBuilder = new StringBuilder();
            formOutputBuilder.Append("?name=");
            formOutputBuilder.Append(uxName.GetValue());
            formOutputBuilder.Append("&favoritecolor=");
            formOutputBuilder.Append(uxFavoriteColor.GetValue());
            formOutputBuilder.Append("&city=");
            formOutputBuilder.Append(uxCity.GetValue());

            Response.Redirect("ValidatedFormOutput.aspx");
        }
    }
}