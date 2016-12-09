using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalvaWebApplication.Models.Contact;

namespace HalvaWebApplication.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
			ContactUsModel model = new ContactUsModel();
            return View(model);
        }
		[HttpPost]
		public ActionResult Index(ContactUsModel Model)
		{
			if (ModelState.IsValid)
			{
				return View("ThankYou");
			}
			else
				return View(Model);
		}
    }
}