using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Department
    {
        [Key]
        public Guid DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAdress { get; set; }

    }
}