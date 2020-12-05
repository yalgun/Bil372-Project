using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Works_onViewModel
    {
        public List<Works_onModel> Works_on { get; set; }
        public Works_onViewModel()
        {
            Works_on = new List<Works_onModel>();
        }
    }
}
