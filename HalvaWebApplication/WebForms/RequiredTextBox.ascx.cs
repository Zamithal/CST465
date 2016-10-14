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

		protected string GetLabelText()
		{
			return uxFieldLabel.Text;
		}
		protected void SetLabelText(string LabelText)
		{
			uxFieldLabel.Text = LabelText;
		}
		protected string GetValue()
		{
			return uxTextBox.Text;
		}
		protected void SetValue(string Value)
		{
			uxTextBox.Text = Value;
		}
		protected string GetValidationGroup()
		{
			return uxValidator.ValidationGroup;
		}
		protected void SetValidationGroup(string ValidationGroup)
		{
			uxValidator.ValidationGroup = ValidationGroup;
		}
	}
}