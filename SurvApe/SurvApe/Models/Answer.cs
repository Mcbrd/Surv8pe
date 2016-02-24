using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurvApe.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public virtual Question question { get; set; }
        public string Title { get; set; }
        public string QuestionText { get; set; }
        public string AnswerGivenString { get; set; }
        public int AnswerGivenInt { get; set; }
        public bool AnswerGivenBool { get; set; }
    }
}