using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class PersonelViewModel
    {
        public List<PersonelModel> Personel { get; set; }
        public PersonelViewModel()
        {
            Personel = new List<PersonelModel>();
        }
    }
}