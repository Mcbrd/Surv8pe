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
    public class PossibleAnswersController : Controller
    {
        private SurvApeDB db = new SurvApeDB();

        // GET: PossibleAnswers
        public ActionResult Index()
        {
            return View(db.PossibleAnswers.ToList());
        }

        // GET: PossibleAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PossibleAnswer possibleAnswer = db.PossibleAnswers.Find(id);
            if (possibleAnswer == null)
            {
                return HttpNotFound();
            }
            return View(possibleAnswer);
        }

        // GET: PossibleAnswers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PossibleAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,QuestionText,AnswerOptionString,AnswerOptionInt,AnswerOptionBool")] PossibleAnswer possibleAnswer)
        {
            if (ModelState.IsValid)
            {
                db.PossibleAnswers.Add(possibleAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(possibleAnswer);
        }

        // GET: PossibleAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PossibleAnswer possibleAnswer = db.PossibleAnswers.Find(id);
            if (possibleAnswer == null)
            {
                return HttpNotFound();
            }
            return View(possibleAnswer);
        }

        // POST: PossibleAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,QuestionText,AnswerOptionString,AnswerOptionInt,AnswerOptionBool")] PossibleAnswer possibleAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(possibleAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(possibleAnswer);
        }

        // GET: PossibleAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PossibleAnswer possibleAnswer = db.PossibleAnswers.Find(id);
            if (possibleAnswer == null)
            {
                return HttpNotFound();
            }
            return View(possibleAnswer);
        }

        // POST: PossibleAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PossibleAnswer possibleAnswer = db.PossibleAnswers.Find(id);
            db.PossibleAnswers.Remove(possibleAnswer);
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
