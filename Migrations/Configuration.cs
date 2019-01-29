namespace ProjetJB2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ProjetJB2.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetJB2.Models.ProjetJB2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ProjetJB2.Models.ProjetJB2Context";
        }

        protected override void Seed(ProjetJB2.Models.ProjetJB2Context context)
        {
            var teachers = new List<Teacher>
            {
                new Teacher { Id = 1, LastName = "BENZAKKI", FirstName = "Judith", Login = "BJ", Password ="benzakkijudith", Email="benzakki.judith@osp.net" },
                new Teacher { Id = 2, LastName = "HAIRAPIAN", FirstName = "Julien", Login = "HJ", Password ="hairapianjulien", Email="hairapian.julien@osp.net" }
            };
            teachers.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student{ Id = 1, LastName = "IBN SALAH", FirstName = "Yacine", Login ="ISY", Password="ibnsalahyacine", Email="ibnsalah.yacine@osp.net" },
                new Student{ Id = 2, LastName = "GREY", FirstName = "Steven", Login = "GS", Password = "greysteven", Email = "grey.steven@osp.net" },
                new Student{ Id = 3, LastName = "HASSINI", FirstName = "Mohammed", Login = "HM", Password = "hassinimohammed", Email = "hassini.mohammed@osp.net" }
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var projects = new List<Project>
            {
                new Project{ Id = 1, Name ="Outil de Suivi de Projet", Description="Les élèves doivent développer une API Web permettant aux professeurs de suivre les projets de groupe.", TeacherId = 1, BeginDate=DateTime.Now.Date, EndDate=DateTime.Now.Date.AddDays(7) }
            };
            projects.ForEach(p => context.Projects.Add(p));
            context.SaveChanges();

            var tasks = new List<Task>
            {
                new Task{ Id = 1, Description ="Coder la page d'authentification", BeginDate=DateTime.Now.Date, EndDate=DateTime.Now.Date.AddDays(1), State=true, ProjectId=1, StudentId=2},
                new Task{ Id = 2, Description ="Coder les fonctionnalités de l'API", BeginDate=DateTime.Now.Date, EndDate=DateTime.Now.Date.AddDays(7), State =true, ProjectId=1, StudentId = 1}
            };
            tasks.ForEach(t => context.Tasks.Add(t));
            context.SaveChanges();

            var steps = new List<Step>
            {
                new Step{ Id = 1, Description ="Rendu du cahier des charges", BeginDate = DateTime.Now.Date, EndDate=DateTime.Now.Date.AddDays(2),ProjectId =1, Notable=true },
                new Step{ Id = 1, Description ="Rendu du rapport de conception final", BeginDate = DateTime.Now.Date, EndDate=DateTime.Now.Date.AddDays(2),ProjectId =1, Notable=true, Rate=10}
            };
            steps.ForEach(st => context.Steps.Add(st));
            context.SaveChanges();

            var Groups = new List<Group>
            {
            new Group{Id=1, NumGroup=1, ProjectId=1, StudentId=1,},
            new Group{Id=1, NumGroup=1, ProjectId=1, StudentId=2,},
            new Group{Id=1, NumGroup=1, ProjectId=1, StudentId=3,}
            };
            Groups.ForEach(s => context.Groups.Add(s));
            context.SaveChanges();
        }

    }
}
