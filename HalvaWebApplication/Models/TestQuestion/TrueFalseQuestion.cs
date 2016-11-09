using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HalvaWebApplication.Models.TestQuestion
{
	public class TrueFalseQuestion : TestQuestion
	{
		[Required]
		[RegularExpression("^True|False$", ErrorMessage = "Only \"True\" or \"False\" is allowed.")]
		public override string Answer { get; set; }
	}
}