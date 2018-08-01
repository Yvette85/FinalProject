﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Activity
    {

        public int ActivityId { get; set; }

        [DisplayName("NameOfActivities")]

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }



        public virtual Module Module { get; set; }
        [DisplayName("ModuleName")]

        public int ModuleId { get; set; }



    }
}