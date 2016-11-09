using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HalvaWebApplication.Models.TestQuestion
{
	public class ShortAnswerQuestion : TestQuestion
	{
		[Required]
		[MaxLength(100)]
		public override string Answer { get; set; }
	}
}