using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models.ViewModels
{
    public class UserViewModel
    {
        public ApplicationUser u;

        public UserViewModel(RegisterViewModel r)

        {

            FirstName = r.FirstName;
            LastName = r.LastName;
            Email = r.Email;





        }

        public UserViewModel(ApplicationUser u)
        {
            this.u = u;
            FirstName = u.FirstName;
            LastName = u.LastName;
            Email = u.Email;
            //Role = u.RoleId ;
        }

      

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }


}
