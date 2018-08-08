using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models.ViewModels
{
    public class IndexHistory
    {

  
     
            public ApplicationUser u;

        public IndexHistory()
        {
        }

        public IndexHistory(ApplicationUser u)
        {
            Id = u.Id;
            FirstName = u.FirstName;
            LastName = u.LastName;


        }



        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }


}

