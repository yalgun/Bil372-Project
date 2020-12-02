using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class PersonelModel
    {
        [Key]
        public int ID { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }

        public string email { get; set; }
        public string username { get; set; }

        public string parola { get; set; }

        public string adres { get; set; }

        public string telefon { get; set; }

        public string meslek { get; set;  }

        public int dno { get; set; }

        public double maas { get; set; }


        [ForeignKey("dno")]
        public Department Deparment { get; set; }


    }
}