using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HalvaWebApplication.Models.TestQuestion;

namespace HalvaWebApplication.Controllers
{
    public class MidtermController : Controller
    {
		[HttpGet]
		public ActionResult TakeTest()
		{
			return View(GetTestQuestions());
		}

		[HttpPost]
		public ActionResult TakeTest(List<TestQuestion> Answers)
		{
			List<TestQuestion> questions = GetTestQuestions();

			SortedDictionary<int, TestQuestion> questionAnswerMap = new SortedDictionary<int, TestQuestion>();

			foreach(TestQuestion question in questions)
				questionAnswerMap[question.ID].Question = question.Question;
			foreach (TestQuestion answer in Answers)
				questionAnswerMap[answer.ID].Answer = answer.Answer;

			// Make into list.
			List<TestQuestion> questionAnswerList = new List<TestQuestion>();

			foreach (KeyValuePair<int, TestQuestion> pair in questionAnswerMap)
				questionAnswerList.Add(pair.Value);

			if (ModelState.IsValid)
			{
				TempData["TestData"] = questionAnswerList;
				return RedirectToAction("DisplayResults");
			}
			else
				return View(questionAnswerList);
		}

		[HttpGet]
		public ActionResult DisplayResults()
		{
			List<TestQuestion> questions = TempData["TestData"] as List<TestQuestion>;

			return View(questions);
		}


		public List<TestQuestion> GetTestQuestions()
		{
			List<TestQuestion> questions = new
				System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<TestQuestion>>("~/JSON/Midterm.json");

			return questions;
		}

    }
}