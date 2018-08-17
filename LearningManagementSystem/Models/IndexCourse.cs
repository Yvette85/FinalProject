using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class IndexCourse
    {

        public int Id { get; set; }
        [DisplayName("CourseName")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CourseEnd { get; set; }

        public List<IndexModule> Modules { get; set; }
    }
}