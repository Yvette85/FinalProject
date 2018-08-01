using LearningManagementSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public UserManager<IdentityUser> userManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();






        // GET: User

        [Authorize(Roles = "Teacher")]
        public ActionResult Register()
        {

            ApplicationDbContext context = new ApplicationDbContext();

            var courses = context.Courses.ToList();
            var viewModel = new RegisterViewModel();


            viewModel.Roles = context.Roles.ToList();
            viewModel.Courses = context.Courses.ToList();

            return View(viewModel);
        }
        
          

       

        [HttpPost]
        public ActionResult Register( RegisterViewModel model)
        {
            var userStore = new UserStore<IdentityUser>();

    


            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);

           



            var identityResult =  userManager.Create ( new IdentityUser( model.Email),  model.Password);



            if (identityResult.Succeeded)
            {

                
                var userId = User.Identity.GetUserId();
                var user = context.Users.Single(u => u.Id == userId);

             


                context.Users.Add(user);
                context.SaveChanges();

                return RedirectToAction("Index" ,"Home");
            }


          

            model.Courses = context.Courses.ToList();
            model.Roles = context.Roles.ToList();



            ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());

            return View(model);
        }

        
    }
}

