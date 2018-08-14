//using LearningManagementSystem.Models;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;

//namespace LearningManagementSystem.viewModel
//{
//    public class ModuleFormViewModel
//    {
//        [DisplayName("ModuleName")]
//        public string Name { get; set; }
//        public string Description { get; set; }

//        [Display(Name = "Start Date")]
//        [Required(ErrorMessage = "Please enter a start date")]
//        [DataType(DataType.Date)]
//        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
//        public DateTime Start_Date { get; set; }

//        [Display(Name = "End Date")]
//        [Required(ErrorMessage = "Please enter a start date")]
//        [DataType(DataType.Date)]
//        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
//        public DateTime End_Date { get; set; }

//        //public string Course { get; set; }
//        public IEnumerable<Course> Courses {get; set;}

//        public virtual Course Course { get; set; }

//        [DisplayName("CourseName")]
//        public int CourseId { get; set; }


//    }
//}