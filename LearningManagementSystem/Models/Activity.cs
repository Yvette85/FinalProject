﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Activity
    {

        public int ActivityId { get; set; }
        [Display(Name = "Name of Activity")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        [Display(Name ="Start Time")]
        public DateTime Start_Time { get; set; }
        [Display(Name="End Time")]
        public DateTime End_Time { get; set; }



        public virtual Module Module { get; set; }
        public int ModuleId { get; set; }


    }
}