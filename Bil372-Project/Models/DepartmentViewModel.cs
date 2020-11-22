using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class DepartmentViewModel
    {
        public List<Department> Departments { get; set; }
        public DepartmentViewModel()
        {
            Departments = new List<Department>();
        }
    }

    
}