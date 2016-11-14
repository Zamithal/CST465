using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HalvaWebApplication.Models.TestQuestion
{
	public class MultipleChoiceQuestion : TestQuestion
	{
		[Required]
		public override string Answer { get; set; }
		public List<string> Choices { get; set; }
	}
}