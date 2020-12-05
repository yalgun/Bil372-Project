using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class SalaryViewModel
    {
        public List<SalaryModel> SalaryModels { get; set; }
        public SalaryViewModel()
        {
            SalaryModels = new List<SalaryModel>();
        }
    }
}