using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizLibrary;

namespace QuizWebApp.Controllers
{
    public class QuizManagerController : Controller
    {
        private static QuizRepository _quizRepo = new QuizRepository();

        // GET: QuizManager
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_quizRepo.GetQuestions());
        }

        // GET: QuizManager/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
        }

        [AllowAnonymous]
        // GET: QuizManager/Create
        public ActionResult Create()
        {
            ViewBag.QuestionTypeList = _quizRepo.GetQuestionTypes();
            return View();
        }

        // POST: QuizManager/Create
        [HttpPost]
        public ActionResult Create(QuizQuestion newQuestion, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                _quizRepo.AddQuestion(newQuestion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuizManager/Edit/5
        [AllowAnonymous]
        public ActionResult Edit(int id)
        {
            ViewBag.QuestionTypeList = _quizRepo.GetQuestionTypes();
            return View(_quizRepo.GetQuestionById(id));
        }

        // POST: QuizManager/Edit/5
        [HttpPost]
        public ActionResult Edit(QuizQuestion newQuestion)
        {
            try
            {
                // TODO: Add update logic here
                _quizRepo.UpdateQuestionById(newQuestion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuizManager/Delete/5
        [AllowAnonymous]
        public ActionResult Delete(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
        }

        // POST: QuizManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _quizRepo.DeleteQuestion(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
