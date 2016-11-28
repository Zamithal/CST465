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
	public class GameItemCategoryDBRepository : IDataEntityRepository<GameItemCategory>
	{
		public GameItemCategory Get(int id)
		{
			GameItemCategory category = new GameItemCategory();

			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
			{
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "SELECT * FROM Category WHERE ID=@ID";
					command.Parameters.AddWithValue("@ID", id);
					command.Connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							category.ID = Int32.Parse(reader["ID"].ToString());
							category.CategoryName = reader["CategoryName"].ToString();
						}
					}
				}
			}

			return category;
		}

		public List<GameItemCategory> GetList()
		{
			List<GameItemCategory> categories = new List<GameItemCategory>();

			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
			{
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "SELECT * FROM Category";
					command.Connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							GameItemCategory category = new GameItemCategory();
							category.ID = Int32.Parse(reader["ID"].ToString());
							category.CategoryName = reader["CategoryName"].ToString();

							categories.Add(category);
						}
					}
				}
			}

			return categories;
		}

		public void Save(GameItemCategory category)
		{
			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
			{
				using (SqlCommand command = new SqlCommand())
				{
					if (category.ID == 0)
					{
						command.CommandText = "INSERT INTO Category(CategoryName) VALUES(@CategoryName)";
					}
					else
					{
						command.CommandText = "Update Category SET CategoryName=@CategoryName WHERE ID=@ID";

						command.Parameters.AddWithValue("@ID", category.ID);
					}

					command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
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
					command.CommandText = "DELETE FROM Category WHERE ID=@ID";
					command.Parameters.AddWithValue("@ID", id);
					command.Connection = connection;
					command.Connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

	}
}