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
        public List<CompletedSurvey> csList = new List<CompletedSurvey>();
        public List<Question> qList = new List<Question>();


        // GET: Questions
        [Authorize]
        public ActionResult Index(int? id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());
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
            if(user.Id == survey.PollsterID)
            {
  
                List<Question> lastHope = survey.questionList;

                List<decimal> amultidecimalList = new List<decimal>();
                List<decimal> bmultidecimalList = new List<decimal>();
                List<decimal> cmultidecimalList = new List<decimal>();
                List<decimal> dmultidecimalList = new List<decimal>();

                foreach (Question i in lastHope)
                {
                    var textAnswer = from t in db.CompletedSurveys
                                     where t.AnswerGivenString.Length > 1
                                     select t;
                    List<CompletedSurvey> tAnswer = textAnswer.ToList();
                    ViewBag.Text = tAnswer;

                    var multichoice = from m in db.CompletedSurveys
                                      where m.SurveyID == i.SurveyID //change to question type multiple choice(add multi to database)
                                      select m;
                    List<CompletedSurvey> multiAnswers = multichoice.ToList();
                    decimal multiResponses = multiAnswers.Count();
                    List<CompletedSurvey> AAnswers = new List<CompletedSurvey>();
                    List<CompletedSurvey> BAnswers = new List<CompletedSurvey>();
                    List<CompletedSurvey> CAnswers = new List<CompletedSurvey>();
                    List<CompletedSurvey> DAnswers = new List<CompletedSurvey>();

                    foreach (CompletedSurvey a in multiAnswers)
                    {
                        if (a.AnswerGivenString == "A")
                        {
                            AAnswers.Add(a);
                        }
                    }
                    foreach (CompletedSurvey b in multiAnswers)
                    {
                        if (b.AnswerGivenString == "B")
                        {
                            BAnswers.Add(b);
                        }
                    }
                    foreach (CompletedSurvey c in multiAnswers)
                    {
                        if (c.AnswerGivenString == "C")
                        {
                            CAnswers.Add(c);
                        }
                    }
                    foreach (CompletedSurvey d in multiAnswers)
                    {
                        if (d.AnswerGivenString == "D")
                        {
                            DAnswers.Add(d);
                        }
                    }
                    decimal aResponse = AAnswers.Count();
                    decimal aPercent = (aResponse / multiResponses) * 100;
                    amultidecimalList.Add(aPercent);
                    ViewBag.aPercent = amultidecimalList;
                    decimal bResponse = BAnswers.Count();
                    decimal bPercent = (bResponse / multiResponses) * 100;
                    bmultidecimalList.Add(bPercent);
                    ViewBag.bPercent = bmultidecimalList;
                    decimal cResponse = CAnswers.Count();
                    decimal cPercent = (cResponse / multiResponses) * 100;
                    cmultidecimalList.Add(cPercent);
                    ViewBag.cPercent = cmultidecimalList;
                    decimal dResponse = DAnswers.Count();
                    decimal dPercent = (dResponse / multiResponses) * 100;
                    dmultidecimalList.Add(dPercent);
                    ViewBag.dPercent = dmultidecimalList;

                }


                List<decimal> decimalList = new List<decimal>();
                foreach (Question i in lastHope)
                {
                       
                     var q2 = from a in db.CompletedSurveys
                         where a.SurveyID == i.SurveyID 
                         select a;
                List<CompletedSurvey> allAnswers = q2.ToList();
                decimal totalResponses = allAnswers.Count();

                List<CompletedSurvey> trueAnswers = new List<CompletedSurvey>();

                foreach (CompletedSurvey a in allAnswers)
                {
                    if (a.AnswerGivenBool == true)
                    {
                        trueAnswers.Add(a);
                    }
                }
                decimal trueResponse = trueAnswers.Count();
                decimal Percent = (trueResponse / totalResponses) * 100;//percent display
                    decimalList.Add(Percent);
            }
              
                var query = from a in db.CompletedSurveys
                            where a.SurveyID == id - 1//id match between tables
                            select a;

                var answer= from a in db.CompletedSurveys
                            where a.AnswerGivenBool == true
                            select a;

                List<CompletedSurvey> secondList = new List<CompletedSurvey>();
                foreach (CompletedSurvey dud in query)
                {
                    if (secondList.Contains(dud))
                        break;
                    else secondList.Add(dud);
  
                }
              
                csList = secondList;

                var question = from q in db.Questions
                               where q.AnswerOptionBool == true
                               select q;
                
                List<Question> QuestionList = question.ToList();

                qList = lastHope;
                var tupleModel = new Tuple<List<CompletedSurvey>, List<Question>>(csList, qList);
                ViewBag.Percent = decimalList;
                foreach (Question item in survey.questionList)
                {
                    viewList.Add(item);
                }
                return View("tupleModel", tupleModel);

            }
            else
            {
                foreach (Question item in survey.questionList)
            {
                viewList.Add(item);
            }
            
            return View(viewList);
            }

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
        public ActionResult Create([Bind(Include = "ID,Title,QuestionText,AnswerOptionString,AnswerOptionBool,Type,UserID,SurveyID")] Question question, Survey survey )
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
                    cs.AnswerGivenString = item.AnswerOptionString;
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
