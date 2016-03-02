using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurvApe.Models;
using SurvApe.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SurvApe.Controllers
{
    public class SurveysController : Controller
    {
        private SurvApeDB db = new SurvApeDB();
        Models.TrueOrFalseQuestion tf = new TrueOrFalseQuestion();
        // GET: Surveys
        public ActionResult Index(Survey survey)
        {
            TempData["survey"] = survey;

            return View(db.Surveys.ToList());

                    //public ActionResult Index(int id)

            //Survey survey = db.Surveys.Single(x => x.ID == id)/*.Single(x => x.ID == id)*/;
            //var surveyViewModel = new SurveyViewModel(survey);
            //return View(surveyViewModel);



            //return View();
        }

        // GET: Surveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title")] Survey survey)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());
            TempData["survey"] = survey;
            if (ModelState.IsValid)
            {
                string UserID = user.Id;
                survey.UserID = UserID;
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Create", "Questions");
            }

            return View(survey);

            //if (ModelState.IsValid)
            //{
            //    db.Surveys.Add(survey);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(survey);
        }

        // GET: Surveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
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
