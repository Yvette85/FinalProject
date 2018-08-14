using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models.ViewModels
{
    public class StudIndex
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Course Course { get; set; }
        public int? CourseId { get; set; }
        public string Email { get; set; }



    }
}