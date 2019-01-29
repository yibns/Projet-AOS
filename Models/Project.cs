using Foolproof;
using ProjetJB2.Controllers;
using System;
using System.ComponentModel;

namespace ProjetJB2.Models
{
    public class Project
    {
        public int Id { get; set; }
        [DisplayName("Title")]
        public String Name { get; set; }
        public String Description { get; set; }
        [DisplayName("Teacher")]
        public Nullable<int> TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        [DisplayName("Starting date")]
        public DateTime BeginDate { get; set; }
        [DisplayName("Ending date")]
        // Classe à parfaire 
        [GreaterThan("BeginDate")]
        public DateTime EndDate { get; set; }
    }
}