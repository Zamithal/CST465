using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HalvaWebApplication.Code.Interfaces;
namespace HalvaWebApplication.Code.DataObjects
{
	public class GameItem : IDataEntity
	{
		public int ID { get; set; }
		public string ItemCode { get; set; }
		public string ItemName { get; set; }
		public int ItemCategoryID { get; set; }
		public string ItemDescription { get; set; }
		public int ItemAttributeID { get; set; }
		public int ItemAttributeQuantity { get; set; }
		public int ItemImage { get; set; }
		public int ItemPrice { get; set; }
	}
}