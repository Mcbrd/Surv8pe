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
    public class CompletedSurveysController : Controller
    {
        private SurvApeDB db = new SurvApeDB();

        // GET: CompletedSurveys
        public ActionResult Index()
        {
            return View(db.CompletedSurveys.ToList());
        }

        // GET: CompletedSurveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompletedSurvey completedSurvey = db.CompletedSurveys.Find(id);
            if (completedSurvey == null)
            {
                return HttpNotFound();
            }
            return View(completedSurvey);
        }

        // GET: CompletedSurveys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompletedSurveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,QuestionText,AnswerGivenString,AnswerGivenInt,AnswerGivenBool")] CompletedSurvey completedSurvey)
        {
            if (ModelState.IsValid)
            {
                db.CompletedSurveys.Add(completedSurvey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(completedSurvey);
        }

        // GET: CompletedSurveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompletedSurvey completedSurvey = db.CompletedSurveys.Find(id);
            if (completedSurvey == null)
            {
                return HttpNotFound();
            }
            return View(completedSurvey);
        }

        // POST: CompletedSurveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,QuestionText,AnswerGivenString,AnswerGivenInt,AnswerGivenBool")] CompletedSurvey completedSurvey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(completedSurvey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(completedSurvey);
        }

        // GET: CompletedSurveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompletedSurvey completedSurvey = db.CompletedSurveys.Find(id);
            if (completedSurvey == null)
            {
                return HttpNotFound();
            }
            return View(completedSurvey);
        }

        // POST: CompletedSurveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompletedSurvey completedSurvey = db.CompletedSurveys.Find(id);
            db.CompletedSurveys.Remove(completedSurvey);
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
