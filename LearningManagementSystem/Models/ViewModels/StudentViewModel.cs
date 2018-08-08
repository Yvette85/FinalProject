using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models.ViewModels
{
    public class StudentViewModel
    {
        public ApplicationUser u;

        public StudentViewModel(ApplicationUser u)
        {
            this.u = u;
            FirstName = u.FirstName;
            LastName = u.LastName;
        
   
        }

      

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
     
      
    }


}
