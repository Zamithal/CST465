using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HalvaWebApplication.Code.Interfaces;

namespace HalvaWebApplication.Code.DataObjects
{
	public class GameItemCategory : IDataEntity
	{
		public int ID { get; set; }
		public string CategoryName { get; set; }
	}
}