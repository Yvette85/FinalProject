namespace LearningManagementSystem.Migrations
{
    using LearningManagementSystem.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
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

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var emails = new[] { "teacher@lexicon.se", "student@lexicon.se" };

            foreach (var email in emails)
            {
                if (context.Users.Any(u => u.UserName == email)) continue;

                var user = new ApplicationUser { UserName = email, Email = email };
                var result = userManager.Create(user, "lexico");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            }


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

            var teacherUser = userManager.FindByName("teacher@lexicon.se");
            userManager.AddToRole(teacherUser.Id, "Teacher");

            var studentUser = userManager.FindByName("student@lexicon.se");
            userManager.AddToRole(studentUser.Id, "Student");

            //var john = userManager.FindByName("john@lexicon.se");
            //userManager.AddToRoles(john.Id, "Admin", "Editor");




            //var courses = new[] {
            //    new Course { Name = "c#", Description = "fundementals", StartDate= 2018-07-27 00:00:00},
            //    new Member { FirstName = "Bo", LastName = "Bosson", Email = "bo@inter.net" },
            //    new Member { FirstName = "George", LastName = "Gershwing", Email = "george@inter.net" },
            //    new Member { FirstName = "Juliet", LastName = "Johnson", Email = "juliet@inter.net" },
            //    new Member { FirstName = "Harold", LastName = "Haroldson", Email = "harold@inter.net" }

            //     };
            ////context.Members.AddOrUpdate(s => s.FirstName, members);
            ////context.Members.AddOrUpdate(s => s.LastName, members);
            //context.Members.AddOrUpdate(s => s.Email, members);

            //context.SaveChanges();

        }


    }
}
