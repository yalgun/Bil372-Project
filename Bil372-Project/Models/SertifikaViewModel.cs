using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class SertifikaViewModel
    {
        public List<SertifikaModel> SertifikaModels { get; set; }
        public SertifikaViewModel()
        {
            SertifikaModels = new List<SertifikaModel>();
        }
    }
}