using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public DateTime CourseStartDate { get; set; }

        public virtual ICollection<ApplicationUser> Students { get; set; }


    }
}

