using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurvApe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SurvApe.Controllers
{
    public class PollstersController : Controller
    {
        private SurvApeDB db = new SurvApeDB();

        // GET: Pollsters
        public ActionResult Index()
        {
            //ApplicationDbContext context = new ApplicationDbContext();
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var Users = context.Users.Select(x => new SelectListItem
            //{
            //    Value = x.UserName,
            //    Text = x.UserName
            //});
            return View(db.Pollsters.ToList());
        }

        // GET: Pollsters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pollster pollster = db.Pollsters.Find(id);
            if (pollster == null)
            {
                return HttpNotFound();
            }
            return View(pollster);
        }

        // GET: Pollsters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pollsters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,MiddleName,LastName,Email,Phone,Address,State,Country,Zipcode,Age,Gender,Company,JobTitle,Salary")] Pollster pollster)
        {
            if (ModelState.IsValid)
            {
                db.Pollsters.Add(pollster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pollster);
        }

        // GET: Pollsters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pollster pollster = db.Pollsters.Find(id);
            if (pollster == null)
            {
                return HttpNotFound();
            }
            return View(pollster);
        }

        // POST: Pollsters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,Email,Phone,Address,State,Country,Zipcode,Age,Gender,Company,JobTitle,Salary")] Pollster pollster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pollster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pollster);
        }

        // GET: Pollsters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pollster pollster = db.Pollsters.Find(id);
            if (pollster == null)
            {
                return HttpNotFound();
            }
            return View(pollster);
        }

        // POST: Pollsters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pollster pollster = db.Pollsters.Find(id);
            db.Pollsters.Remove(pollster);
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
