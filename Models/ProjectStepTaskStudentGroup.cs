using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetJB2.Models
{
    public class ProjectStepTaskStudentGroup
    {
        public Project Project { get; set; }
        public Step Step { get; set; }
        public Task Task { get; set; }
        public List<Student> Students { get; set; }
        public List<Group> Group { get; set; }


        public ProjectStepTaskStudentGroup(Project p, Step s, Task t, List<Student> st, List<Group> g)
        {
            this.Project = p;
            this.Step = s;
            this.Task = t;
            this.Students = st;
            this.Group = g;
        }
    }

}