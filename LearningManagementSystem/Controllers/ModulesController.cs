using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LearningManagementSystem.Models;


namespace LearningManagementSystem.Controllers
{
    public class ModulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Modules
        public ActionResult Index()
        {
            //var modules = db.Modules.Include(m => m.Course);
            

            List<IndexModule> module = new List<IndexModule>();
            foreach (var g in db.Modules.ToList())
            {
                module.Add(new IndexModule()
                {
                    ModuleId = g.ModuleId,
                    Name = g.Name,
                    Description = g.Description,
                    Start = g.Start,
                    EndDate = g.EndDate, 
                    CourseId = Convert.ToInt32(g.CourseId)               
                    
                });
            }

            IndexModuleViewModels modulemodel = new IndexModuleViewModels();
            modulemodel.Modules = module.Where(x => x.Start > DateTime.Now).ToList();

            return View(modulemodel);
        }

        // GET: Modules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            //var model = new Module()
            //{
            //    ListCourse = db.Courses,
            //};
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModuleId,Name,Description,Start,EndDate,CourseId")] IndexModule createmodule)
        {      

           // var Course = module.Courses.Id.ToString();
            
            if (ModelState.IsValid)     
            {
                var module = new Module()
                {
                    ModuleId = createmodule.ModuleId,
                    Name = createmodule.Name,
                    Description = createmodule.Description,
                    Start = createmodule.Start,
                    EndDate = createmodule.EndDate,
                    CourseId = Convert.ToString(createmodule.CourseId),
                };



                db.Modules.Add(module);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            //ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", createmodule.CourseId);
            //return View(createmodule);

           return View(createmodule);
        }

        // GET: Modules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Start,End")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(module);
        }

        // GET: Modules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Module module = db.Modules.Find(id);
            db.Modules.Remove(module);
            db.SaveChanges();
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
