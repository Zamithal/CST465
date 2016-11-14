using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json.Linq;

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

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult TakeTest(List<TestQuestion> Answers)
		{
			List<TestQuestion> questions = GetTestQuestions();

			SortedDictionary<int, TestQuestion> questionAnswerMap = new SortedDictionary<int, TestQuestion>();

			foreach (TestQuestion question in questions)
			{
				questionAnswerMap[question.ID] = question;
			}
			foreach(TestQuestion answer in Answers)
			{
				questionAnswerMap[answer.ID].Answer = answer.Answer;
			}
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
			string fullPath = HttpContext.Server.MapPath(@"/JSON/Midterm.json");

			string testContents = null;

			using (StreamReader reader = new StreamReader(fullPath))
			{
				testContents = reader.ReadToEnd();
				reader.Close();
			}

			if (testContents == null)
			{
				return new List<TestQuestion>();
			}

			JArray questionStrings = JArray.Parse(testContents);

			List<TestQuestion> questions = new List<TestQuestion>();

			foreach(JToken token in questionStrings)
			{
				TestQuestion newQuestion = null;

				string type = token.Value<string>("type");

				switch(type)
				{
					case "TrueFalseQuestion":
						newQuestion = token.ToObject<TrueFalseQuestion>();
						break;
					case "ShortAnswerQuestion":
						newQuestion = token.ToObject<ShortAnswerQuestion>();
						break;
					case "LongAnswerQuestion":
						newQuestion = token.ToObject<LongAnswerQuestion>();
						break;
					case "MultipleChoiceQuestion":
						newQuestion = token.ToObject<MultipleChoiceQuestion>();
						break;
					default:
						throw new ArgumentException("Unknown question type");
				}

				questions.Add(newQuestion);
			}


			return questions;

		}

    }
}