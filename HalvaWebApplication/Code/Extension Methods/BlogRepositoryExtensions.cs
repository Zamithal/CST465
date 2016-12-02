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
			contains = Blogs.GetList().Where(post => post.Title.Contains(SearchString) || post.Content.Contains(SearchString)).ToList();

			return contains;
		}
	}
}