using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class SertifikaModel
    {
        [Key]
        public int ID { get; set; }
        public string sertifika_adi { get; set; }
        public DateTime sertifika_tarihi { get; set; }

        public string sertifika_aciklama { get; set; }




    }
}