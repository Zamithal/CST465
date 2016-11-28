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
    public class GameItemController : Controller
    {
		public GameItemController(IDataEntityRepository<GameItem> ItemInterface, IDataEntityRepository<GameItemCategory> CategoryInterface)
		{
			m_repository = ItemInterface;
			m_categoryRepository = CategoryInterface;
		}

        // GET: GameItem
        public ActionResult Index()
        {
			List<GameItem> items = m_repository.GetList();

            return View(items);
        }

		public ActionResult Display(int ID)
		{
			GameItem item = m_repository.Get(ID);

			return View(item);
		}

		public ActionResult Add()
		{
			Models.GameItem.GameItemModel model = new Models.GameItem.GameItemModel();

			return View(model);
		}

		[HttpPost]
		public ActionResult Add(Models.GameItem.GameItemModel Model)
		{
			if (ModelState.IsValid)
			{
				GameItem item = new GameItem();
				item.ID = Model.ID;
				item.ItemCode = Model.ItemCode;
				item.ItemName = Model.ItemName;
				item.ItemCategoryID = Model.ItemCategory.ID;
				item.ItemDescription = Model.ItemDescription;
				item.ItemAttributeID = 1;
				item.ItemAttributeQuantity = Model.ItemAttributeQuantity;
				item.ItemImage = item.ItemImage;
				item.ItemPrice = item.ItemPrice;
			}
			else
				return View(Model);

			return RedirectToAction("Index");
		}

		public ActionResult Edit(int ID)
		{
			GameItem item = m_repository.Get(ID);

			Models.GameItem.GameItemModel model = new Models.GameItem.GameItemModel();

			if (item != null)
			{
				model.ID = item.ID;
				model.ItemCode = item.ItemCode;
				model.ItemName = item.ItemName;
				model.ItemCategory = m_categoryRepository.Get(item.ItemCategoryID);
				model.ItemDescription = item.ItemDescription;
				model.ItemAttributeName = "Weapon";
				model.ItemAttributeQuantity = item.ItemAttributeQuantity;
				model.ItemImage = item.ItemImage;
				model.ItemPrice = item.ItemPrice;
			}
			else
				return RedirectToAction("Index");

			return View(model);
		}

		[HttpPost]
		public ActionResult Edit(Models.GameItem.GameItemModel Model)
		{
			if (ModelState.IsValid)
			{
				GameItem item = new GameItem();
				item.ID = Model.ID;
				item.ItemCode = Model.ItemCode;
				item.ItemName = Model.ItemName;
				item.ItemCategoryID = Model.ItemCategory.ID;
				item.ItemDescription = Model.ItemDescription;
				item.ItemAttributeID = 1;
				item.ItemAttributeQuantity = Model.ItemAttributeQuantity;
				item.ItemImage = Model.ItemImage;
				item.ItemPrice = Model.ItemPrice;
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

		private IDataEntityRepository<GameItem> m_repository;
		private IDataEntityRepository<GameItemCategory> m_categoryRepository;
    }
}