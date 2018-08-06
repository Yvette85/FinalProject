using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models.ViewModels
{
    public class UserViewModel
    {
        private ApplicationUser u;

        public UserViewModel(RegisterViewModel r)

        {

            FirstName = r.FirstName;
            LastName = r.LastName;
            Email = r.Email;

            RoleId = r.RoleId;



        }

        public UserViewModel(ApplicationUser u)
        {
            this.u = u;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RoleId { get; set; }
    }


}
