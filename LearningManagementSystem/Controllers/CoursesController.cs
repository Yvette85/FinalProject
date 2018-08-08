using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LearningManagementSystem.Models;
using LearningManagementSystem.Models.ViewModels;

namespace LearningManagementSystem.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Courses
        public ActionResult IndexHistory()
        {
            
            
            return View(db.Courses.ToList());
        }


        public ActionResult Index()
        {
            List<IndexCourse> course = new List<IndexCourse>();
            foreach (var s in context.Courses.ToList())
            {
               course.Add(new IndexCourse()
                {
                   Id = s.Id,
                   Name = s.Name,
                   StartDate =s.StartDate,
                   Description = s.Description,
                   
            
                });
            }
            IndexCourseViewModel ic = new IndexCourseViewModel();

           ic.Courses = course.Where(x => x.StartDate > DateTime.Now).ToList();

            return View(ic);
          
        }




        //        List<IndexCourse> course = new List<IndexCourse>();
        //            foreach (var g in db.Courses.ToList())
        //            {
        //                course.Add(new IndexCourse()
        //        {
        //            Id = g.Id,
        //                    Name = g.Name,
        //                    StartDate = g.StartDate,
        //                    Description = g.Description,



        //                });
        //            }

        //    IndexCourseViewModel coursemodel = new IndexCourseViewModel();
        //    coursemodel.Courses = course.Where(x => x.StartDate > DateTime.Now).ToList();

        //            return View(coursemodel);
        //}




        //public ActionResult Index()
        //{
        //    var viewModel = new RegisterViewModel();

        //    //viewModel.users = context.Users.ToList();


        //    List<StudentViewModel> rv = new List<StudentViewModel>();
        //    RegisterViewModel model = new RegisterViewModel();


        //    foreach (var u in context.Users.ToList())
        //    {
        //        rv.Add(new StudentViewModel(u));
        //    }

        //    var Role = context.Roles.FirstOrDefault(x => x.Id == model.RoleId);
        //    viewModel.Roles = context.Roles.ToList();

        //    //var User = userManager.FindByName(model.Email);
        //    //userManager.AddToRole(User.Id, Role.Name);

        //    return View(rv);



        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartDate")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartDate")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
