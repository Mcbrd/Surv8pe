using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurvApe.Models;

namespace SurvApe.Controllers
{
    public class TrueOrFalseQuestionsController : Controller
    {
        private SurvApeDB db = new SurvApeDB();

        // GET: TrueOrFalseQuestions
        public ActionResult Index()
        {
            return View(db.TrueOrFalseQuestions.ToList());
        }

        // GET: TrueOrFalseQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrueOrFalseQuestion trueOrFalseQuestion = db.TrueOrFalseQuestions.Find(id);
            if (trueOrFalseQuestion == null)
            {
                return HttpNotFound();
            }
            return View(trueOrFalseQuestion);
        }

        // GET: TrueOrFalseQuestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrueOrFalseQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Text,Type,Answer")] TrueOrFalseQuestion trueOrFalseQuestion)
        {
            if (ModelState.IsValid)
            {
                db.TrueOrFalseQuestions.Add(trueOrFalseQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trueOrFalseQuestion);
        }

        // GET: TrueOrFalseQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrueOrFalseQuestion trueOrFalseQuestion = db.TrueOrFalseQuestions.Find(id);
            if (trueOrFalseQuestion == null)
            {
                return HttpNotFound();
            }
            return View(trueOrFalseQuestion);
        }

        // POST: TrueOrFalseQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Text,Type,Answer")] TrueOrFalseQuestion trueOrFalseQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trueOrFalseQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trueOrFalseQuestion);
        }

        // GET: TrueOrFalseQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrueOrFalseQuestion trueOrFalseQuestion = db.TrueOrFalseQuestions.Find(id);
            if (trueOrFalseQuestion == null)
            {
                return HttpNotFound();
            }
            return View(trueOrFalseQuestion);
        }

        // POST: TrueOrFalseQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrueOrFalseQuestion trueOrFalseQuestion = db.TrueOrFalseQuestions.Find(id);
            db.TrueOrFalseQuestions.Remove(trueOrFalseQuestion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
