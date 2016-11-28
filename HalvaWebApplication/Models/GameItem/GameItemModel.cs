using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HalvaWebApplication.Code.DataObjects;


namespace HalvaWebApplication.Models.GameItem
{
	public class GameItemModel
	{
		public int ID { get; set; }
		public string ItemCode { get; set; }
		public string ItemName { get; set; }
		public GameItemCategory ItemCategory { get; set; }
		public string ItemDescription { get; set; }
		public string ItemAttributeName { get; set; }
		public int ItemAttributeQuantity { get; set; }
		public int ItemImage { get; set; }
		public int ItemPrice { get; set; }
	}
}