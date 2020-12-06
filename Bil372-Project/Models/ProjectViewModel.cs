using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class ProjectViewModel
    {
        public List<ProjectModel> ProjectModels { get; set; }
        public ProjectViewModel()
        {
            ProjectModels = new List<ProjectModel>();
        }
    }
}
