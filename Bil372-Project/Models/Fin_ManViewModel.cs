using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Fin_ManViewModel
    {
        public List<Fin_ManModel> Fin { get; set; }
        public Fin_ManViewModel()
        {
            Fin = new List<Fin_ManModel>();
        }
    }
}