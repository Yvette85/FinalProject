using LearningManagementSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public UserManager<IdentityUser> userManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();


        //public ActionResult Index(ApplicationUser u)
        //{

        //    var viewModel = new RegisterViewModel();

        //    viewModel.Roles = context.Roles.ToList();
        //    viewModel.Courses = context.Courses.ToList();

         

        //    List<RegisterViewModel> rv = new List<RegisterViewModel>();

        //    foreach (var e in context.Users.ToList())
        //    {
               
        //        rv.Add(new RegisterViewModel());
        //    }

        //    return View(context.Users.ToList());

        //}



        // GET: User

        [Authorize(Roles = "Teacher")]
        public ActionResult Register()
        {

            ApplicationDbContext context = new ApplicationDbContext();

            var viewModel = new RegisterViewModel();
             
            viewModel.Roles = context.Roles.ToList();
            viewModel.Courses = context.Courses.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register( RegisterViewModel model)
        {
            var userStore = new UserStore<IdentityUser>();

            var user = new ApplicationUser();
            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);

            var identityResult=  userManager.Create ( new IdentityUser( model.Email),  model.Password);

            if (identityResult.Succeeded)
            {
                // var Roles = context.Roles.ToList();

                //context.Users.Add(user);
                //context.SaveChanges();

                return RedirectToAction("Index" ,"Home");
            }

            ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());

            return View(model);
        }

    }
}


//var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
//if (ModelState.IsValid)
//           {
//               db.Courses.Add(course);
//               db.SaveChanges();
//               return RedirectToAction("Index");
//           }

//           return View(course);