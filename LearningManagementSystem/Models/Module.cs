using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Module
    {
        public int ModuleId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        
         [Column(TypeName = "datetime2")]
        public DateTime Start { get; set; }
       
         [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        public virtual Course Course { get; set; }

        public int CourseId { get; set; }

        

               

    }
}