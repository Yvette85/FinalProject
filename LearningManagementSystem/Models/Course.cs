using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Course Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Display(Name="Start Date")]
        [Required(ErrorMessage = "Please enter a start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }


        public virtual ICollection<ApplicationUser> Students { get; set; }

        public virtual ICollection<Module> Modules { get; set; }

    }
}

  