﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class IndexModule
    {
        [Key]
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
       [Column(TypeName = "datetime2")]
        public DateTime Start_Date { get; set; }
       
        [Column(TypeName = "datetime2")]
        public DateTime End_Date { get; set; }

        [Required]
        public int CourseId { get; set; }        
        
        //public List<IndexModule> Modules { get; set; }
        public IEnumerable<Course> ListCourse { get; set; }
       

    }
}