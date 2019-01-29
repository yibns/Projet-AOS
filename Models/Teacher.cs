using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjetJB2.Models
{
    public class Teacher
    {
        [DisplayName("Teacher")]
        public int Id { get; set; }
        [DisplayName("Teacher")]
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
    }
}