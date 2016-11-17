using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalvaWebApplication.Code.Interfaces;
using HalvaWebApplication.Code.DataObjects;
using HalvaWebApplication.Code.Repositories;
using HalvaWebApplication.Code.Extension_Methods;

namespace HalvaWebApplication.Controllers
{
    public class BlogController : Controller
    {
		public BlogController(IDataEntityRepository<BlogPost> dataInterface)
		{
			m_repository = dataInterface;
		}

        public ActionResult Index()
        {
			List<BlogPost> blogs = m_repository.GetList();
			return View(blogs);
        }

		[HttpPost]
		public ActionResult Index(string Filter)
		{
			List<BlogPost> blogs = m_repository.GetListByContent(Filter);
			return View(blogs);
		}

		public ActionResult Show(int ID)
		{
			BlogPost post = m_repository.Get(ID);

			if (post != null)
				return View(post);
			else
				return View();
		}

		public ActionResult Add()
		{
			Models.BlogPostModel blog = new Models.BlogPostModel();

			return View(blog);
		}

		[HttpPost]
		public ActionResult Add(Models.BlogPostModel model)
		{
			if (ModelState.IsValid)
			{
				BlogPost post = new BlogPost();
				post.ID = model.ID;
				post.Author = model.Author;
				post.Title = model.Title;
				post.Content = model.Content;

				m_repository.Save(post);
			}

			return RedirectToAction("Index");
		}


		public ActionResult Edit(int id)
		{
			BlogPost blog = m_repository.Get(id);
			Models.BlogPostModel model = new Models.BlogPostModel();
			{
				model.ID = blog.ID;
				model.Author = blog.Author;
				model.Title = blog.Title;
				model.Content = blog.Content;
			}

			return View(model);
		}

		[HttpPost]
		public ActionResult Edit(Models.BlogPostModel model)
		{
			if (ModelState.IsValid)
			{
				BlogPost post = new BlogPost();
				post.ID = model.ID;
				post.Author = model.Author;
				post.Title = model.Title;
				post.Content = model.Content;

				m_repository.Save(post);
			}
			else
				return View(model);

			return RedirectToAction("Index");
		}

		private IDataEntityRepository<BlogPost> m_repository;

    }
}