﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalvaWebApplication.Code.Interfaces;
using HalvaWebApplication.Code.DataObjects;
using HalvaWebApplication.Models.GameItem;
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
			List<GameItemModel> models = new List<GameItemModel>();

			List<SelectListItem> categories = constructCategoryList();

			foreach(GameItem item in items)
			{
				GameItemModel newItem = new GameItemModel(item);
				newItem.CategoryList = categories;
			}

            return View(models);
        }

		public ActionResult Display(int ID)
		{
			GameItemModel model = new GameItemModel(m_repository.Get(ID));
			model.CategoryList = constructCategoryList();

			return View(model);
		}

		public ActionResult Add()
		{
			GameItemModel model = new GameItemModel();
			model.CategoryList = constructCategoryList();

			return View(model);
		}

		[HttpPost]
		public ActionResult Add(GameItemModel Model)
		{
			if (ModelState.IsValid)
			{
				GameItem item = new GameItem();
				item.ID = Model.ID;
				item.ItemCode = Model.ItemCode;
				item.ItemName = Model.ItemName;
				item.ItemCategoryID = Model.ItemCategoryID;
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

			GameItemModel model = new GameItemModel();

			if (item != null)
			{
				model.ID = item.ID;
				model.ItemCode = item.ItemCode;
				model.ItemName = item.ItemName;
				model.ItemCategoryID = item.ItemCategoryID;
				model.ItemDescription = item.ItemDescription;
				model.ItemAttributeID = 0;
				model.ItemAttributeQuantity = item.ItemAttributeQuantity;
				model.ItemImage = item.ItemImage;
				model.ItemPrice = item.ItemPrice;
				model.CategoryList = constructCategoryList();
			}
			else
				return RedirectToAction("Index");

			return View(model);
		}

		[HttpPost]
		public ActionResult Edit(GameItemModel Model)
		{
			if (ModelState.IsValid)
			{
				GameItem item = new GameItem();
				item.ID = Model.ID;
				item.ItemCode = Model.ItemCode;
				item.ItemName = Model.ItemName;
				item.ItemCategoryID = Model.ItemCategoryID;
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

		private List<SelectListItem> constructCategoryList()
		{
			List<SelectListItem> categoryList = new List<SelectListItem>();
			m_categoryRepository.GetList().ForEach(listItem => categoryList.Add(new SelectListItem() { Text = listItem.CategoryName, Value = listItem.ID.ToString() }));

			return categoryList;
		}


		private IDataEntityRepository<GameItem> m_repository;
		private IDataEntityRepository<GameItemCategory> m_categoryRepository;
    }
}