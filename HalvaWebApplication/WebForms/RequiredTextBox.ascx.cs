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

		public string GetLabelText()
		{
			return uxFieldLabel.Text;
		}
        public void SetLabelText(string LabelText)
		{
			uxFieldLabel.Text = LabelText;
		}
        public string GetValue()
		{
			return uxTextBox.Text;
		}
        public void SetValue(string Value)
		{
			uxTextBox.Text = Value;
		}
        public string GetValidationGroup()
		{
			return uxValidator.ValidationGroup;
		}
        public void SetValidationGroup(string ValidationGroup)
		{
			uxValidator.ValidationGroup = ValidationGroup;
		}
	}
}