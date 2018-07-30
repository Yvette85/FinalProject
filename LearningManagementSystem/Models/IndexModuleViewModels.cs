using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class IndexModuleViewModels
    {
        public List<IndexModule> Modules { get; set; }
        public ICollection<Course> ListCourse { get; set; }
    }
}