
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Talent_ManageViewModel
    {
        public List<Talent_ManageModel> Talent { get; set; }
        public Talent_ManageViewModel()
        {
            Talent = new List<Talent_ManageModel>();
        }
    }
}