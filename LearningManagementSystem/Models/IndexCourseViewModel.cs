using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models.ViewModels
{
    public class IndexCourseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<IndexCourse> Courses{ get; set; }
    }
}