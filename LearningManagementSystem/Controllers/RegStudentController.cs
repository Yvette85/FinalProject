using LearningManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    [Authorize]
    public class RegStudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: RegStudent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CourseId")] Course course)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Courses.Add(course);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(course);
        //}



    }
}