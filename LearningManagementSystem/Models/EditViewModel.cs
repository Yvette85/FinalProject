using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models.ViewModels
{
    public class EditViewModel
    {
        public ApplicationUser u;

        public EditViewModel()
        {
        }

        public EditViewModel(ApplicationUser u)
        {
            Id = u.Id;
            FirstName = u.FirstName;
            LastName = u.LastName;
            Email = u.Email;
        }



        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }




    }
}