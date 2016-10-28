using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HalvaWebApplication.Controllers
{
    public class BlogController : Controller
    {
		public BlogController()
		{
			m_repository = new Code.Repositories.BlogDBRepository();
		}


        // GET: Blog
        public ActionResult Index()
        {
			List<Code.DataObjects.BlogPost> blogs = m_repository.GetList();
			return View(blogs);
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
				Code.DataObjects.BlogPost post = new Code.DataObjects.BlogPost();
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
			Code.DataObjects.BlogPost blog = m_repository.Get(id);
			Models.BlogPostModel model = new Models.BlogPostModel();
			{
				model.ID = blog.ID;
				model.Author = model.Author;
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
				Code.DataObjects.BlogPost post = new Code.DataObjects.BlogPost();
				post.ID = model.ID;
				post.Author = model.Author;
				post.Title = model.Title;
				post.Content = model.Content;

				m_repository.Save(post);
			}

			return RedirectToAction("Index");
		}

		private Code.Interfaces.IDataEntityRepository<Code.DataObjects.BlogPost> m_repository;

    }
}