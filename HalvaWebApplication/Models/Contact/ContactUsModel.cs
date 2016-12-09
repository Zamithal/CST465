using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HalvaWebApplication.Models.Contact
{
	public class ContactUsModel
	{
		[Required]
		public string Name { get; set; }
		[Required]
		[RegularExpression(@"(\(\d{3}\)|\d{3}\-)\d{3}\-\d{4}")]
		public string PhoneNumber { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Reason { get; set; }
	}
}