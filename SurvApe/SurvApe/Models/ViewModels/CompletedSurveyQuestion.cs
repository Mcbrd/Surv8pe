using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurvApe.Models.ViewModels
{
    public class CompletedSurveyQuestion
    {
        public List<CompletedSurvey> completdSurvey { get; set; }
        public Question surveyQuestion { get; set; }
    }
}