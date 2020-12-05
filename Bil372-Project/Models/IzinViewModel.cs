using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class IzinViewModel
    {
        public List<IzinModel> Izin { get; set; }
        public IzinViewModel()
        {
            Izin = new List<IzinModel>();
        }
    }
}