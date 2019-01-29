using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetJB2.Models
{
    public class Step
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public DateTime BeginDate { get; set; }
        [GreaterThan("BeginDate")]
        public DateTime EndDate { get; set; }
        [Range(0, 20, ErrorMessage = "The rate must be between 0 and 20")]
        public Nullable<int> Rate { get; set; }
        public Boolean Notable { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}