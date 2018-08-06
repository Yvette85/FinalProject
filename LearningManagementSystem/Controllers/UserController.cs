using LearningManagementSystem.Models;
using LearningManagementSystem.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

            List<UserViewModel> rv = new List<UserViewModel>();

            foreach (var u in context.Users.ToList())
            {
                rv.Add(new UserViewModel (u));
            }

            return View(rv);

            //var viewModel = new RegisterViewModel();

            //var users = context.Users.ToList();

            //viewModel.users = context.Users.ToList();

            //return View(viewModel);
        }


        //List<IndexVehicle> iv = new List<IndexVehicle>();

       

        //    foreach (ParkedVehicle e in parkedVehicle.ToList())

        //    {
        //        iv.Add(new IndexVehicle(e));
              
        //    }
        //    return View(iv);


    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user  = context.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


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
            var userStore = new UserStore<ApplicationUser>(context);


            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);




            if (ModelState.IsValid)
            {
               var user = new ApplicationUser { Email = model.Email ,UserName = model.Email, FirstName = model.FirstName, LastName = model.LastName };



                var identityResult = userManager.Create( user, model.Password);
                //(new IdentityUser (model.Email), model.Password);


          



                if (identityResult.Succeeded)
                {
                    //userManager.AddToRole(user.Id, "Student");


                    //var roleStore = new RoleStore<IdentityRole>(context);
                    //var roleManager = new RoleManager<IdentityRole>(roleStore);



                    //var roleNames = new[] { "Teacher", "Student" };
                    //foreach (var roleName in roleNames)
                    //{
                    //    if (context.Roles.Any(r => r.Name == roleName)) continue;

                    //    var role = new IdentityRole { Name = roleName };
                    //    var result = roleManager.Create(role);
                    //    if (!result.Succeeded)
                    //    {
                    //        throw new Exception(string.Join("\n", result.Errors));
                    //    }
                    //}
                    var Role = context.Roles.FirstOrDefault(x => x.Id == model.RoleId);

                    var User = userManager.FindByName(model.Email);
                    //userManager.AddToRole(User.Id, context.Roles.FirstOrDefault(x => x.Id == model.RoleId).Name);
                    userManager.AddToRole(User.Id, Role.Name);

                    //context.Roles.FirstOrDefault(x => x.Id == model.RoleId);




                    //context.Users.Add(user);
                    //context.SaveChanges();
             

                    return RedirectToAction("Index", "Home");
                }


                
                  



                ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());

                
            }

            model.Courses = context.Courses.ToList();

            model.Roles = context.Roles.ToList();

            return View(model);

        }


        public ActionResult Edit(int? id)
        {

 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user =context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email")]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                context.Entry(User).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(User);
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
