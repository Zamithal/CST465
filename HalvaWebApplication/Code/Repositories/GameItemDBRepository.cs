using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

using HalvaWebApplication.Code.DataObjects;
using HalvaWebApplication.Code.Interfaces;

namespace HalvaWebApplication.Code.Repositories
{
	public class GameItemDBRepository : IDataEntityRepository<GameItem>
	{
		public GameItem Get(int id)
		{
			GameItem item = new GameItem();

			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
			{
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "SELECT * FROM GameItem WHERE ID=@ID";
					command.Parameters.AddWithValue("@ID", id);
					command.Connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							item.ID = Int32.Parse(reader["ID"].ToString());
							item.ItemCode = reader["ItemCode"].ToString();
							item.ItemName = reader["ItemName"].ToString();
							item.ItemCategoryID = Int32.Parse(reader["ItemCategoryID"].ToString());
							item.ItemDescription = reader["ItemDescription"].ToString();
							item.ItemAttributeID = Int32.Parse(reader["ItemGivenAttributeID"].ToString());
							item.ItemAttributeQuantity = Int32.Parse(reader["ItemGivenAttributeQuanitiy"].ToString());
							item.ItemPrice = Int32.Parse(reader["ItemPrice"].ToString());
						}
					}
				}

			}

			return item;
		}

		public List<GameItem> GetList()
		{
			List<GameItem> items = new List<GameItem>();

			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
			{
				using (SqlCommand itemCommand = new SqlCommand())
				{
					itemCommand.Connection = connection;
					itemCommand.CommandText = "SELECT * FROM GameItem";
					itemCommand.Connection.Open();
					using (SqlDataReader itemReader = itemCommand.ExecuteReader())
					{
						while (itemReader.Read())
						{
							GameItem item = new GameItem();
							item.ID = Int32.Parse(itemReader["ID"].ToString());
							item.ItemCode = itemReader["ItemCode"].ToString();
							item.ItemName = itemReader["ItemName"].ToString();
							item.ItemCategoryID = Int32.Parse(itemReader["ItemCategoryID"].ToString());
							item.ItemDescription = itemReader["ItemDescription"].ToString();
							item.ItemAttributeID = Int32.Parse(itemReader["ItemGivenAttributeID"].ToString());
							item.ItemAttributeQuantity = Int32.Parse(itemReader["ItemGivenAttributeQuantity"].ToString());
							item.ItemPrice = Int32.Parse(itemReader["ItemPrice"].ToString());

							items.Add(item);
						}
					}
				}
			}
			return items;
		}

		public void Save(GameItem item)
		{
			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
			{
				using (SqlCommand command = new SqlCommand())
				{
					if (item.ID == 0)
					{
						command.CommandText = "INSERT INTO GameItem(" +
											  "ItemCode, ItemName, ItemCategoryID, ItemDescription, ItemGivenAttributeID, ItemGivenAttributeQuantity, ItemImage, ItemPrice" +
											  ") VALUES(" +
											  "@ItemCode, @ItemName, @ItemCategoryID, @ItemDescription, @ItemGivenAttributeID, @ItemGivenAttributeQuantity, @ItemImage, @ItemPrice" +
											  ")";
					}
					else
					{
						command.CommandText = "Update GameItem SET" +
											  "ItemCode=@ItemCode, ItemName=@ItemName, ItemDescription=@ItemDescription" +
											  "ItemGivenAttributeID=@ItemGivenAttributeID, ItemGivenAttributeQuantity=@ItemGivenAttributeQuantity" +
											  "ItemImage=@ItemImage, ItemPrice=@ItemPrice";

						command.Parameters.AddWithValue("@ID", item.ID);
					}

					command.Parameters.AddWithValue("@ItemCode", item.ItemCode);
					command.Parameters.AddWithValue("@ItemName", item.ItemName);
					command.Parameters.AddWithValue("@ItemCategoryID", item.ItemCategoryID);
					command.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);
					command.Parameters.AddWithValue("@ItemGivenAttributeID", item.ItemAttributeID);
					command.Parameters.AddWithValue("@ItemGivenAttributeQuantity", item.ItemAttributeQuantity);
					command.Parameters.AddWithValue("@ItemImage", item.ItemImage);
					command.Parameters.AddWithValue("@ItemPrice", item.ItemPrice);
					command.Connection = connection;
					command.Connection.Open();
					command.ExecuteNonQuery();
				}

			}
		}

		public void Delete(int id)
		{
			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
			{
				using (SqlCommand command = new SqlCommand())
				{
					command.CommandText = "DELETE FROM GameItem WHERE ID=@ID";
					command.Parameters.AddWithValue("@ID", id);
					command.Connection = connection;
					command.Connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

	}
}