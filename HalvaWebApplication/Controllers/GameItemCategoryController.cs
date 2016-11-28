using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalvaWebApplication.Code.Interfaces;
using HalvaWebApplication.Code.DataObjects;
using HalvaWebApplication.Code.Repositories;

namespace HalvaWebApplication.Controllers
{
    public class GameItemCategoryController : Controller
    {
		// Constructor
		public GameItemCategoryController(IDataEntityRepository<GameItemCategory> DataInterface)
		{
			m_repository = DataInterface;
		}


        // GET: GameItemCategory
        public ActionResult Index()
        {
			List<GameItemCategory> categories = m_repository.GetList();
            return View(categories);
        }


		public ActionResult Add()
		{
			ViewBag.validCategories = m_repository.GetList();

			Models.GameItem.GameItemCategoryModel model = new Models.GameItem.GameItemCategoryModel();

			return View(model);
		}

		[HttpPost]
		public ActionResult Add(Models.GameItem.GameItemCategoryModel Model)
		{
			if (ModelState.IsValid)
			{
				GameItemCategory category = new GameItemCategory();
				category.ID = Model.ID;
				category.CategoryName = Model.CategoryName;

				m_repository.Save(category);
			}
			else
				return View(Model);

			return RedirectToAction("Index");
		}


		public ActionResult Edit(int ID)
		{
			ViewBag.validCategories = m_repository.GetList();

			GameItemCategory item = m_repository.Get(ID);

			Models.GameItem.GameItemCategoryModel model = new Models.GameItem.GameItemCategoryModel();

			if (item != null)
			{
				model.ID = item.ID;
				model.CategoryName = item.CategoryName;
			}
			else
				return RedirectToAction("Index");

			return View(model);
		}

		[HttpPost]
		public ActionResult Edit(Models.GameItem.GameItemCategoryModel Model)
		{
			if (ModelState.IsValid)
			{
				GameItemCategory category = new GameItemCategory();
				category.ID = Model.ID;
				category.CategoryName = Model.CategoryName;

				m_repository.Save(category);
			}
			else
				return View(Model);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Delete(int ID)
		{
			m_repository.Delete(ID);

			return RedirectToAction("Index");
		}


		private IDataEntityRepository<GameItemCategory> m_repository;
    }
}