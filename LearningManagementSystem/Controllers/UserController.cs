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

            // ApplicationDbContext context = new ApplicationDbContext();

            var viewModel = new RegisterViewModel();

            //ViewBag.CourseId = context.Courses.Select(c => c.Name);
           
            //var course = context.Courses.Select(c => c.Name);

            viewModel.Roles = context.Roles.ToList();
            viewModel.Courses = context.Courses.ToList();

            return View(viewModel);
        }






        //var course = context.Courses.Select(c => c.Name);

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var userStore = new UserStore<IdentityUser>();


            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);



            model.Courses = context.Courses.ToList();

            model.Roles = context.Roles.ToList();


            if (ModelState.IsValid)
            {
               var user = new ApplicationUser { Email = model.Email , UserName= model.Email,/*CourseId = model.CourseId,*/ FirstName = model.FirstName, LastName = model.LastName };



                var identityResult = userManager.Create( new IdentityUser(model.Email), model.Password);
                    //(new IdentityUser (model.Email), model.Password);
                     


                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Student");

                    //var teacherUser = userManager.FindByName(model.Email);
                    //userManager.AddToRole(teacherUser.Id, context.Roles.FirstOrDefault(x=>x.Id==model.RoleId).Name);

                    context.Roles.FirstOrDefault(x => x.Id == model.RoleId);
                   
                 
                    context.Users.Add(user);
                    context.SaveChanges();
             

                    return RedirectToAction("Index", "Home");
                }


                
                  



                ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());

                
            }
            return View(model);

        }
    }
}

//public async Task<ActionResult> Register(RegisterViewModel model)
//{
//    if (ModelState.IsValid)
//    {
//        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

//        var result = await UserManager.CreateAsync(user, model.Password);



//        if (result.Succeeded)
//        {
