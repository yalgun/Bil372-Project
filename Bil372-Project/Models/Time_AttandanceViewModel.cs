using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Time_AttandanceViewModel
    {
        public List<Time_AttandanceModel> Time_att { get; set; }
        public Time_AttandanceViewModel()
        {
            Time_att = new List<Time_AttandanceModel>();
        }
    }
}