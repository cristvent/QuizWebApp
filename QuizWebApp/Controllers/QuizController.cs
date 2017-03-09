using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizLibrary;

namespace QuizWebApp.Controllers
{
    public class QuizController : Controller
    {
        private static QuizStorage _quizStorage = new QuizStorage();
        // GET: Quiz
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_quizStorage.GetQuizAll());
        }

        // GET: Quiz/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View(_quizStorage.GetQuizById(id));
        }

        // GET: Quiz/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quiz/Create
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(Quiz newQuiz, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                _quizStorage.AddQuiz(newQuiz);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Edit/5
        [AllowAnonymous]
        public ActionResult Edit(int id)
        {
            return View(_quizStorage.GetQuizById(id));
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Quiz quizChanged, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _quizStorage.EditQuiz(id, quizChanged);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Delete/5
        [AllowAnonymous]
        public ActionResult Delete(int id)
        {
            return View(_quizStorage.GetQuizById(id));
        }

        // POST: Quiz/Delete/5
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Delete(int id, Quiz newQuiz, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _quizStorage.DeleteContent(id, newQuiz);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
