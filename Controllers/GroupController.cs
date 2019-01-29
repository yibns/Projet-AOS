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
    public class GroupController : Controller
    {
        private ProjetJB2Context db = new ProjetJB2Context();

        // GET: Group //EN PLEIN TEST
        public async Task<ActionResult> Index()
        {
            var groups = db.Groups.Include(g => g.Project).Include(g => g.Student);

            /* List<List<int>> grouplist = new List<List<int>>();
             List<int> students = new List<int>();
             for(int i=1;i<db.Groups.Max(g => g.NumGroup); i++) { 
                 foreach(var group in db.Groups.Where(g => g.NumGroup == i){
                         //students.Add(group.StudentId);
                        var studentlist = from s in db.Groups
                                    select s.StudentId;
                     foreach(var stud in studentlist) { 
                        students.Add(stud

                 }*/
            return View(await groups.ToListAsync());
        }

        // GET: Group/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "LastName");
            return View();
        }

        // POST: Group/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NumGroup,ProjectId,StudentId")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", group.ProjectId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "LastName", group.StudentId);
            return View(group);
        }

        // GET: Group/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", group.ProjectId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "LastName", group.StudentId);
            return View(group);
        }

        // POST: Group/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NumGroup,ProjectId,StudentId")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", group.ProjectId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "LastName", group.StudentId);
            return View(group);
        }

        // GET: Group/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Group group = await db.Groups.FindAsync(id);
            db.Groups.Remove(group);
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
