using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.Web.Script.Serialization;

using HalvaWebApplication.Code.DataObjects;
using HalvaWebApplication.Code.Interfaces;

namespace HalvaWebApplication.Code.Repositories
{
	public class BlogFileRepository : IDataEntityRepository<BlogPost>
	{
		public BlogPost Get(int id)
		{

			return GetList().Where(post => post.ID == id).FirstOrDefault<BlogPost>();

		}

		public List<BlogPost> GetList()
		{
			string fullPath = HttpContext.Current.Server.MapPath(@"/App_Data/BlogPosts.json");

			StreamReader stream = null;
			string RepositoryContents = null;

			try
			{
				using (stream = new StreamReader(fullPath))
				{
					// Read all characters
					RepositoryContents = stream.ReadToEnd();
					stream.Close();
				}
				
			}
			catch
			{
				return null;
			}


			JavaScriptSerializer deserializer = new JavaScriptSerializer();
			List<BlogPost> blogPosts = null;
			try
			{
				blogPosts = deserializer.Deserialize<List<BlogPost>>(RepositoryContents);
			}
			catch
			{
				return null;
			}

			return blogPosts;
		}

		public void Save(BlogPost entity)
		{
			List<BlogPost> blogPosts = GetList();

			if(entity.ID == 0)
			{
				if (blogPosts == null || blogPosts.Count == 0)
					entity.ID = 1;
				else
					entity.ID = blogPosts.Max(blog => blog.ID) + 1;
			}

			if(blogPosts == null)
			{
				blogPosts = new List<BlogPost>();
			}

			BlogPost editedPost = blogPosts.Find(post => post.ID == entity.ID);
			if (editedPost == null)
				blogPosts.Add(entity);
			else
			{
				editedPost.Title = entity.Title;
				editedPost.Author = entity.Author;
				editedPost.Content = entity.Content;
			}

			string fullPath = HttpContext.Current.Server.MapPath(@"/App_Data/Blogposts.json");

			using (StreamWriter stream = new StreamWriter(fullPath, false))
			{
				JavaScriptSerializer serializer = new JavaScriptSerializer();

				string encodedBlogs = serializer.Serialize(blogPosts);
				stream.Write(encodedBlogs);
				stream.Close();
			}
		}
	}
}