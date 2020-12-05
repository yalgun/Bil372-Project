using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Acik_PozisyonViewModel
    {
        public List<Acik_PozisyonModel> Acik_PozisyonModels { get; set; }
        public Acik_PozisyonViewModel()
        {
            Acik_PozisyonModels = new List<Acik_PozisyonModel>();
        }
    }
}