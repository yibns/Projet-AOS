using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetJB2.Models;

namespace ProjetJB2.Controllers
{
    public class ProjectController : Controller
    {
        private ProjetJB2Context db = new ProjetJB2Context();

        public ViewResult Index(String searchString)
        {
            var projects = from p in db.Projects
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(p => p.Name.Contains(searchString) || p.Description.Contains(searchString));
            }
            return View(projects.ToList());
        }
        // GET: Project/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            //GERER LES DATES PASSEES
            var task = db.Tasks.Where(x => x.Project.Id == id && x.EndDate > DateTime.Now).OrderBy(x => x.EndDate).FirstOrDefault();            
            var step = db.Steps.Where(x => x.Project.Id == id && x.EndDate > DateTime.Now).OrderBy(x => x.EndDate).FirstOrDefault();
            var students = new List<Student>();
            var group = db.Groups.Where(x => x.NumGroup == id).ToList();
            foreach(var g in group)
            {
                var studentList = db.Students.Where(x => x.Id == g.StudentId).ToList();
                foreach(var student in studentList)
                {
                    students.Add(student);
                }
                
            }
                
            ProjectStepTaskStudentGroup projectsteptaskstudentgroup = new ProjectStepTaskStudentGroup(project, step, task, students, group);
            return View(projectsteptaskstudentgroup);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "LastName");
            return View();
        }

        // POST: Project/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,TeacherId,BeginDate,EndDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "LastName", project.TeacherId);
            return View(project);
        }

        // GET: Project/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "LastName", project.TeacherId);
            return View(project);
        }

        // POST: Project/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,TeacherId,BeginDate,EndDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "LastName", project.TeacherId);
            return View(project);
        }

        // GET: Project/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Project project = await db.Projects.FindAsync(id);
            foreach (var group in db.Groups.Where(g => g.ProjectId == id))
            {
                db.Groups.Remove(group);
            }
            foreach (var step in db.Steps.Where(s => s.ProjectId == id))
            {
                db.Steps.Remove(step);
            }
            foreach (var task in db.Tasks.Where(t => t.ProjectId == id))
            {
                db.Tasks.Remove(task);
            }
            db.SaveChanges();
            db.Projects.Remove(project);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
