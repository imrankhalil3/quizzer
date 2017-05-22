using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizzerApp.Models;
using System.Web.SessionState;
namespace QuizzerApp.Controllers
{
    [SessionState(SessionStateBehavior.Default)]
    public class QuestionController : Controller
    {
       private quzzerContaxt db = new quzzerContaxt();
        // GET: Question
        public ActionResult Index()
        {
            Session["score"] = 0;
            int totleQuestion = db.Questions.Count();
            ViewBag.totleQuestion = totleQuestion;
            return View();
        }

        // GET: Question/Details/5
        public ActionResult Question(int? Id)
        {
            ViewBag.totleQuestion = db.Questions.Count();
            var question = db.Questions.Find(Id);
            ViewBag.choices = db.Choices.Where(c => c.QuestionId == Id);
            return View(question);
        }
        [HttpPost]
        public ActionResult Question()
        {
            int totleQuestion = db.Questions.Count();
            //get selected choice
            int selected_choice = int.Parse(Request["choice"]);
            int question_no = int.Parse(Request["QuestioNumber"]);
            //get correct choice
          Choice c_choice=  db.Choices.Where(c => c.QuestionId == question_no && c.is_correct == true).SingleOrDefault();
            if(selected_choice==c_choice.Id)
            {

                int score = int.Parse(Session["score"].ToString());
                score++;
                Session["score"] = score;
            }
            if (question_no == totleQuestion)
            {
                return RedirectToAction("Final");
            }
            else
            {
                return RedirectToAction("Question", new { Id = ++question_no });
            }
        }
        public ActionResult Final()
        {
            return View();
        }
        // GET: Question/Create
        public ActionResult Create()
        {

            return View();
        }
        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
