using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LearningManagementSystem.Viewmodels
{
    public class ActivityFormViewModel
    {
        [Required]
        [DisplayName("NameOfActivities")]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Type { get; set; }

        [DisplayName("Start Time")]
        public string Start_Time { get; set; }
        [DisplayName("End Time")]
        public string End_Time { get; set; }

        [DisplayName("Select Module")]
        public string  Module { get; set; }

        public IEnumerable<Models.Module> Modules { get; set; }



    }
}