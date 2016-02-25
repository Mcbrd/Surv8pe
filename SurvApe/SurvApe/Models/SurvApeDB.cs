using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace SurvApe.Models
{
    public class SurvApeDB : DbContext
    {
        public SurvApeDB() : base("DefaultConnection")
        {

        }
 
        public System.Data.Entity.DbSet<SurvApe.Models.Question> Questions { get; set; }

        public System.Data.Entity.DbSet<SurvApe.Models.CompletedSurvey> CompletedSurveys { get; set; }

        public System.Data.Entity.DbSet<SurvApe.Models.Answer> Answers { get; set; }

        public System.Data.Entity.DbSet<SurvApe.Models.PossibleAnswer> PossibleAnswers { get; set; }

        public System.Data.Entity.DbSet<SurvApe.Models.Respondant> Respondants { get; set; }

        public System.Data.Entity.DbSet<SurvApe.Models.Pollster> Pollsters { get; set; }

        public System.Data.Entity.DbSet<SurvApe.Models.Survey> Surveys { get; set; }

        public System.Data.Entity.DbSet<SurvApe.Models.TrueOrFalseQuestion> TrueOrFalseQuestions { get; set; }
    }
}