using LearningManagementSystem.Models;
using LearningManagementSystem.Models.ViewModels;
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


        public ActionResult Index()
        {
           // var tesst = context.Users

            List<ApplicationUser> studIndex = new List<ApplicationUser>().ToList();
            foreach (var s in studIndex)
            {
                studIndex.Add(new ApplicationUser()
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    CourseId = s.CourseId,
                    Email = s.Email,

                });

                return RedirectToAction("Index");

            }

            return View(context.Users.ToList());
        }


        //var park = db.Members.ToList();
        ////var parkedVehicle = db.vehicles.ToList();
        //return View(db.Members.ToList());

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
        public ActionResult Register(RegisterViewModel model)
        {
            var userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);

            var identityResult = userManager.Create(new IdentityUser(model.Email), model.Password);

            if (identityResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());

            return View(model);
        }

    }
}


//[Bind(Include = "RegNum,Color,Brand,Model,NumberOfWheels,ParkedTime, MemberId,VehicleTypesId")] Park park