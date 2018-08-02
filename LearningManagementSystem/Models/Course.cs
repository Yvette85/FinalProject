using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }



        //DateTime thisDate = new DateTime(2018, 3, 15);
        //CultureInfo culture = new CultureInfo("pt-BR");
  
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        //public virtual ICollection<ApplicationUser> Users { get; set; }


    }
}
