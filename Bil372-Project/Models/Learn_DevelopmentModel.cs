using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Learn_DevelopmentModel
    {

        [Key]
        public int ID { get; set; }
        public string person_id { get; set; }
        public int sertifika_id { get; set; }

        [ForeignKey("person_id")]
        public PersonelModel Person { get; set; }

        [ForeignKey("sertifika_id")]
        public SertifikaModel Sertifika { get; set; }
    }
}