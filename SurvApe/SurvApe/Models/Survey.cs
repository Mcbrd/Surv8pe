using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SurvApe.Models
{
    public class Survey
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual Pollster pollster { get; set; }
        public string PollsterID { get; set; }
        public string UserID { get; set; }
        public virtual List<Question> questionList{ get; set; }//Icollection or List //public virtual ICollection<Question> Questions { set; get; }
        public Question question { get; set; }                                             
        [Display(Name = "Answer")]
        public int SelectedAnswer { get; set; }
        public Survey()
        {
            questionList = new List<Question>();

        }
    }
}