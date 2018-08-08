using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models.ViewModels
{
  

        public class IndexCourse
        {

            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime CourseEnd { get; set; }
            public string FirstName { get; set; }
           public string LastName { get; set; }

        public List<ApplicationUser> users { get; set; }
        }
    }
}