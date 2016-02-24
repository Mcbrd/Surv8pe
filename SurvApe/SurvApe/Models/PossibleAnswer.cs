using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurvApe.Models
{
    public class PossibleAnswer
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual Question question { get; set; }
        public string QuestionText { get; set; }
        public string AnswerOptionString { get; set; }
        public int AnswerOptionInt { get; set; }
        public bool AnswerOptionBool { get; set; }
    }
}