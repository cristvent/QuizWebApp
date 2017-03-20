using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizLibrary;

namespace QuizWebApp.Controllers
{
    public class GameQuestionAreaController : Controller
    {


        // GET: GameQuestionArea
        public ActionResult Index(int id)
        {
            ViewBag.QuizId = id;
            return View();
        }

        // GET: GameQuestionArea/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GameQuestionArea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameQuestionArea/Create
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

        // GET: GameQuestionArea/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GameQuestionArea/Edit/5
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

        // GET: GameQuestionArea/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GameQuestionArea/Delete/5
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
