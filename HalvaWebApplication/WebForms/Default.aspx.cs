using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace HalvaWebApplication.WebForms
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Init(object sender, EventArgs e)
		{
			this.uxEventOutput.Text += "OnInit Firing!";
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.uxEventOutput.Text += "OnLoad Firing!";
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			this.uxEventOutput.Text += "OnPreRender Firing!";
		}

		protected void uxSubmit_Click(object sender, EventArgs e)
		{
			StringBuilder formOutputBuilder = new StringBuilder();

			formOutputBuilder.Append("Name:");
			formOutputBuilder.Append(uxName);
			formOutputBuilder.Append("<br />");
			formOutputBuilder.Append("Priority:");
			formOutputBuilder.Append(uxPriority);
			formOutputBuilder.Append("<br />");
			formOutputBuilder.Append("Subject:");
			formOutputBuilder.Append(uxSubject);
			formOutputBuilder.Append("<br />");
			formOutputBuilder.Append("Description:");
			formOutputBuilder.Append(uxDescription);
			formOutputBuilder.Append("<br />");

			this.uxFormOutput.Text = formOutputBuilder.ToString();
		}
	}
}