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
    public class RespondantsController : Controller
    {
        private SurvApeDB db = new SurvApeDB();

        // GET: Respondants
        public ActionResult Index()
        {
            return View(db.Respondants.ToList());
        }

        // GET: Respondants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respondant respondant = db.Respondants.Find(id);
            if (respondant == null)
            {
                return HttpNotFound();
            }
            return View(respondant);
        }

        // GET: Respondants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Respondants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,MiddleName,LastName,Address,State,Country,Zipcode,Citizenship,Age,BirthDate,Gender,Company,Salary,Ethnicity,Religion,Education,Employed,PoliticalLeaning")] Respondant respondant)
        {
            if (ModelState.IsValid)
            {
                db.Respondants.Add(respondant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(respondant);
        }

        // GET: Respondants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respondant respondant = db.Respondants.Find(id);
            if (respondant == null)
            {
                return HttpNotFound();
            }
            return View(respondant);
        }

        // POST: Respondants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,Address,State,Country,Zipcode,Citizenship,Age,BirthDate,Gender,Company,Salary,Ethnicity,Religion,Education,Employed,PoliticalLeaning")] Respondant respondant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respondant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(respondant);
        }

        // GET: Respondants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respondant respondant = db.Respondants.Find(id);
            if (respondant == null)
            {
                return HttpNotFound();
            }
            return View(respondant);
        }

        // POST: Respondants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respondant respondant = db.Respondants.Find(id);
            db.Respondants.Remove(respondant);
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
