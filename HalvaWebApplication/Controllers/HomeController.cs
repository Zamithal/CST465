using HalvaWebApplication.Code.DataObjects;
using HalvaWebApplication.Code.Interfaces;
using HalvaWebApplication.Models.GameItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HalvaWebApplication.Controllers
{
    public class HomeController : Controller
    {
		public HomeController(IDataEntityRepository<GameItem> gameItemDataInterface,IDataEntityRepository<BlogPost> blogPostDataInterface)
		{
			m_gameItemRepository = gameItemDataInterface;
			m_blogPostRepository = blogPostDataInterface;
		}


		// GET: Home
		public ActionResult Index()
        {
			List<BlogPost> allPosts = m_blogPostRepository.GetList();
			List<BlogPost> newestPosts = new List<BlogPost>();

			allPosts = allPosts.OrderByDescending(m => m.Timestamp).ToList();

			for(int i = 0; allPosts.Count > i && i < 3; i++)
			{
				newestPosts.Add(allPosts[i]);
			}

			ViewBag.recentPosts = newestPosts;

			List<GameItem> allItems = m_gameItemRepository.GetList();
			List<GameItemModel> displayItems = new List<GameItemModel>();

			for(int i = 0; allItems.Count > i && i < 5; i++)
			{
				displayItems.Add(new GameItemModel(allItems[i]));
			}

			ViewBag.gameItems = displayItems;


            return View();
        }

		private IDataEntityRepository<GameItem> m_gameItemRepository;
		private IDataEntityRepository<BlogPost> m_blogPostRepository;
	}
}