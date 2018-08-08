namespace LearningManagementSystem.Migrations
{
    using LearningManagementSystem.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LearningManagementSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LearningManagementSystem.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var courses = new[]
            {
                new Course { Id=1, Name = ".Net", Description = "Fullstack course", StartDate = DateTime.Now.AddDays(10)},
                new Course { Id=2, Name ="Java", Description ="Java Course", StartDate = DateTime.Now.AddDays(10)},
                new Course { Id=3, Name ="C++", Description ="Fundamentals in C++", StartDate = DateTime.Now.AddDays(-600)}
            };

            context.Courses.AddOrUpdate(c => c.Name, courses);
            context.SaveChanges();

            var modules = new[]
            {
                new Module {Name ="EntityFramwork", Description = "Working with Entity", Start_Date = DateTime.Now.AddDays(10), CourseId=1, End_Date = DateTime.Now.AddDays(110)},
                new Module {Name ="Identity", Description = "Working with Identity", Start_Date = DateTime.Now.AddDays(10), CourseId=1, End_Date = DateTime.Now.AddDays(110)},
                
            };
            context.Modules.AddOrUpdate(m => m.Name, modules);
            context.SaveChanges();

            var activities = new[]
            {
                new Activity {Name = "Listening and learn", Type ="E-Learning", Description ="Watch video 'Fullstack'", Start_Time = DateTime.Now.AddDays(10), End_Time = DateTime.Now.AddDays(110), ModuleId = 1}
            };
            context.Activities.AddOrUpdate(a => a.Name, activities);
            context.SaveChanges();



            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var studs = new[] { new ApplicationUser { FirstName = "Erik", LastName = "Eriksson", Email = "Erik@lexicon.se", CourseId = 1, UserName ="Erik@lexicon.se" } };

            foreach (var stud in studs)
            {
                if (context.Users.Any(u => u.UserName == stud.UserName)) continue;

                //var user = new ApplicationUser { UserName = stud., Email = stud, FirstName = stud, LastName = stud};
                var result = userManager.Create(stud, "lexicon");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            }

            context.Users.AddOrUpdate(u => u.UserName, studs);
            context.SaveChanges();

            
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleNames = new[] { "Teacher", "Student" };
            foreach (var roleName in roleNames)
            {
                if (context.Roles.Any(r => r.Name == roleName)) continue;

                var role = new IdentityRole { Name = roleName };
                var result = roleManager.Create(role);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            }


                



            var erikUser = userManager.FindByName("Erik@lexicon.se");
            userManager.AddToRole(erikUser.Id, "Student");
            erikUser.CourseId = 1;
                //context.Courses.FirstOrDefault

            var davidUser = userManager.FindByName("David@lexicon.se");
            userManager.AddToRole(davidUser.Id, "Student");
            davidUser.CourseId = 1;


            var ahmedUser = userManager.FindByName("Ahmed@lexicon.se");
            userManager.AddToRole(ahmedUser.Id, "Student");
            ahmedUser.CourseId = 2;
            
            var fredrikUser = userManager.FindByName("Fredrik@lexicon.se");
            userManager.AddToRole(fredrikUser.Id, "Student");
            fredrikUser.CourseId = 2;

            var borgeUser = userManager.FindByName("Borge@lexicon.se");
            userManager.AddToRole(borgeUser.Id, "Student");
            borgeUser.CourseId = 1;


            var teacherUser = userManager.FindByName("Teacher@lexicon.se");
            userManager.AddToRole(teacherUser.Id, "Teacher");


            //var john = userManager.FindByName("john@lexicon.se");
            //userManager.AddToRoles(john.Id, "Admin", "Editor");

            //var users = new[]
            //{
            //    new ApplicationUser {}
            //};
           


        }
    }
}
