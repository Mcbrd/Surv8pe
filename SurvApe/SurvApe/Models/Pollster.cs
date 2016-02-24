using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurvApe.Models
{
    public class Pollster
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zipcode { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }

    }
}