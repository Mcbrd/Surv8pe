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
    public class SurveysController : Controller
    {
        private SurvApeDB db = new SurvApeDB();
        Models.TrueOrFalseQuestion tf = new TrueOrFalseQuestion();
        // GET: Surveys
        public ActionResult Index()
        {
            //List<TrueOrFalseQuestion> list = new List<TrueOrFalseQuestion>();

            //list.Add(new TrueOrFalseQuestion { ID = 1, Text = "Aquafina", Answer = false });
              //new TrueOrFalseQuestion { ID = 2, Text = "Mulshi Springs", Answer = false },
              //new TrueOrFalseQuestion { ID = 3, Text = "Alfa Blue", Answer = false },
              //new TrueOrFalseQuestion { ID = 4, Text = "Atlas Premium", Answer = false },
              //new TrueOrFalseQuestion { ID = 5, Text = "Bailley", Answer = false },
              //new TrueOrFalseQuestion { ID = 6, Text = "Bisleri", Answer = false },
              //new TrueOrFalseQuestion { ID = 7, Text = "Himalayan", Answer = false },
              //new TrueOrFalseQuestion { ID = 8, Text = "Cool Valley", Answer = false },
              //new TrueOrFalseQuestion { ID = 9, Text = "Dew Drops", Answer = false },
              //new TrueOrFalseQuestion { ID = 10, Text = "Dislaren", Answer = false });

            

          //  return View();
            return View(db.Surveys.ToList());
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
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survey);
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
