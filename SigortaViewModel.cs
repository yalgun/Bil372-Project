using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class SigortaViewModel
    {
        public List<SigortaModel> SigortaModels { get; set; }
        public SigortaViewModel()
        {
            SigortaModels = new List<SigortaModel>();
        }
    }
}