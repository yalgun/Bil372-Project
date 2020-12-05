using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Benef_ManViewModel
    {
        public List<Benef_ManModel> Benef { get; set; }
        public Benef_ManViewModel()
        {
            Benef = new List<Benef_ManModel>();
        }
    }
}