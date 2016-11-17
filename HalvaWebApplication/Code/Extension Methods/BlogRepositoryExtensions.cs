using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HalvaWebApplication.Code.Interfaces;
using HalvaWebApplication.Code.DataObjects;

namespace HalvaWebApplication.Code.Extension_Methods
{
	public static class BlogRepositoryExtensions
	{
		public static List<BlogPost> GetListByContent(this IDataEntityRepository<BlogPost> Blogs, string SearchString)
		{
			List<BlogPost> contains = new List<BlogPost>();

			foreach (BlogPost blog in Blogs.GetList())
			{
				if (blog.Title.Contains(SearchString))
				{
					contains.Add(blog);
				}
				else if (blog.Content.Contains(SearchString))
				{
					contains.Add(blog);
				}

			}

			return contains;
		}
	}
}