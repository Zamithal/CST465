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
		public GameItemModel(HalvaWebApplication.Code.DataObjects.GameItem Item)
		{
			ID = Item.ID;
			ItemCode = Item.ItemCode;
			ItemName = Item.ItemName;
			ItemCategoryID = Item.ItemCategoryID;
			ItemDescription = Item.ItemDescription;
			ItemAttributeID = Item.ItemAttributeID;
			ItemAttributeQuantity = Item.ItemAttributeQuantity;
			ItemImage = Item.ItemImage;
			ItemPrice = Item.ItemPrice;
		}

		public GameItemModel()
		{ }

		public int ID { get; set; }
		[DisplayName("Code")]
		public string ItemCode { get; set; }
		[DisplayName("Name")]
		public string ItemName { get; set; }
		public int ItemCategoryID { get; set; }
		[DisplayName("Description")]
		public string ItemDescription { get; set; }
		public int ItemAttributeID { get; set; }
		public int ItemAttributeQuantity { get; set; }
		public int ItemImage { get; set; }
		[DisplayName("Price")]
		public int ItemPrice { get; set; }
		public List<SelectListItem> CategoryList { get; set; }
	}
}