using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurvApe.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual Pollster pollster { get; set; }
        public string QuestionText { get; set; }
        public string AnswerOptionString { get; set; }
        public int AnswerOptionInt { get; set; }
        public bool AnswerOptionBool { get; set; }
        public QuestionType Type { get; set; }
        public string UserID { get; set; }



    }
}