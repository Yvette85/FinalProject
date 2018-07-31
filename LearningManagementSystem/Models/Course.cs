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

        
        public string Name { get; set; }

        
        [StringLength(255)]
        public string Description { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

     
        public virtual ICollection<ApplicationUser> Students { get; set; }


    }
}

//var isValid = DateTime.TryParseExact(Convert.ToString(value),
//               "yyyy-mm-dd",