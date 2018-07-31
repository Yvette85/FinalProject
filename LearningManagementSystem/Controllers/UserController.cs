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
        public UserManager<IdentityUser> UserManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();


        // GET: User

        [Authorize(Roles = "Teacher")]
        public ActionResult Register()
        {

            ApplicationDbContext context = new ApplicationDbContext();

            var viewModel = new RegisterViewModel();

            viewModel.Roles = context.Roles.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register( RegisterViewModel model)
        {
           var identityResult= UserManager.Create(new IdentityUser(model.Email), model.Password);
            if (identityResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());
            return View(model);
        }

    }
}