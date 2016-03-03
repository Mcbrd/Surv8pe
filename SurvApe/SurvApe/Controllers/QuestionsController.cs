using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SurvApe.Models
{
    public class QuestionsController : Controller
    {
        private SurvApeDB db = new SurvApeDB();



        // GET: Questions

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Question> viewList = new List<Question>();
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
         
            foreach(Question item in survey.questionList)
            {
                viewList.Add(item);
            }
            
            return View(viewList);

        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,QuestionText,AnswerOptionString,AnswerOptionInt,AnswerOptionBool,UserID, SurveyID")] Question question, Survey survey )
        {
            List<Question> QuestList = new List<Question>();
            survey = (Survey) TempData["survey"];
            string title = survey.Title;
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());


            if (ModelState.IsValid)
            {
                string UserID = user.Id;
                question.PollsterID = UserID;
                question.SurveyID = survey.ID;
                QuestList.Add(question);
                foreach(Question q in QuestList)
                {
                    survey.questionList.Add(q);
                }
                db.Surveys.Add(survey);
                db.SaveChanges();
     
                return RedirectToAction("Create" );
            }

            return View("Create");
        }


        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,QuestionText,AnswerOptionString,AnswerOptionInt,AnswerOptionBool")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }


        [HttpPost]
        public ActionResult Submit(List<Question> model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            CompletedSurvey cs = new CompletedSurvey();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());          
            if (ModelState.IsValid)
            {
                if(model != null)
                    { 

                foreach (Question item in model)
                {
                    string UserID = user.Id;
                    item.UserID = UserID;
                        cs.PollsterID = item.PollsterID;
                    cs.QAList.Add(item);
                        cs.SurveyID = item.SurveyID;
                    cs.AnswerGivenBool = item.AnswerOptionBool;
                    cs.QuestionText = item.QuestionText;
                    cs.RespondantID = UserID;
                    db.CompletedSurveys.Add(cs);
                    db.SaveChanges();                  

                }
                return View();
                }
            }
            return View();

        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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
