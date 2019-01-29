using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetJB2.Models
{
    public class Group
    {
        public int Id { get; set; }
        [DisplayName("NumGroup")]
        [Required(ErrorMessage = "NumGroup is required")]
        [Range(1, int.MaxValue,ErrorMessage = "NumGroup must be a positive number")]
        public int NumGroup { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public Nullable<int> StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}