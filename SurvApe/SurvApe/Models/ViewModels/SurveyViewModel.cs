using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurvApe.Models.ViewModels
{
    public class SurveyViewModel
    {
        public Survey survey { get; set; }

        public Question question { get; set; }
        public QuestionType questionType { get; set; }


        [Obsolete("Only needed for serialization and materialization", true)]
        public SurveyViewModel()
        { }

        public SurveyViewModel(Survey survey)
        { 
        //Survey = survey;
        //Question = new Question();  display questions, answer options
        }
    }

}
