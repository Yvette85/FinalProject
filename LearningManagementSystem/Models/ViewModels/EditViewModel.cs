using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models.ViewModels
{
    public class EditViewModel
    {

        public EditViewModel()
        {

        }
        public EditViewModel(ApplicationUser u)
        {

            FirstName = u.FirstName;
            LastName = u.LastName;
            Email = u.LastName;
        }


        public string Id { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}