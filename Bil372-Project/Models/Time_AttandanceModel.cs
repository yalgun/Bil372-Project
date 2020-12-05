using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Time_AttandanceModel
    {

        [Key]
        public int ID { get; set; }
        public int person_id { get; set; }
        public DateTime giris_saati { get; set; }

        public DateTime cikis_saati { get; set; }

        [ForeignKey("person_id")]
        public PersonelModel PersonModel { get; set; }
    }
}