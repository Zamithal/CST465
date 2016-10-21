using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HalvaWebApplication.WebForms
{
	public partial class RequiredTextBox : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public string LabelText
		{
			get { return uxFieldLabel.Text; }
			set { uxFieldLabel.Text = value; }
		}

		public string TextBoxValue
		{
			get { return uxTextBox.Text; }
			set { uxTextBox.Text = value; }
		}
       
		public string ValidationGroup
		{
			get { return uxValidator.ValidationGroup; }
			set { uxValidator.ValidationGroup = value; }
		}
	}
}