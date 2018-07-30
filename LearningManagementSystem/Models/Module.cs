using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Module
    {

        public int ModuleId { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }


        public Course Course { get; set; }

        public int CourseId { get; set; }




    }
}