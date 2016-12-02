using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HalvaWebApplication.Code.DataObjects;
using System.ComponentModel;
using System.Web.Mvc;

namespace HalvaWebApplication.Models.GameItem
{
	public class GameItemModel
	{
		public GameItemModel(HalvaWebApplication.Code.DataObjects.GameItem)
		{

		}

		public int ID { get; set; }
		[DisplayName("Code")]
		public string ItemCode { get; set; }
		[DisplayName("Name")]
		public string ItemName { get; set; }
		public int ItemCategoryID { get; set; }
		[DisplayName("Description")]
		public string ItemDescription { get; set; }
		public string ItemAttributeName { get; set; }
		public int ItemAttributeQuantity { get; set; }
		public int ItemImage { get; set; }
		[DisplayName("Price")]
		public int ItemPrice { get; set; }
		public List<SelectListItem> CategoryList { get; set; }
	}
}