using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurvApe.Models
{
    public class CompletedSurvey
    {
        public int ID { get; set; }
        public virtual Pollster pollster { get; set; }
        public virtual Respondant respondant { get; set; }
        public virtual Question question { get; set; }
        public virtual Answer answer { get; set; }
        public string Title { get; set; }
        public string QuestionText { get; set; }
        public string AnswerGivenString { get; set; }
        public int AnswerGivenInt { get; set; }
        public bool AnswerGivenBool { get; set; }
    }
}