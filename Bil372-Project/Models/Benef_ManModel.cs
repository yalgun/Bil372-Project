using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Benef_ManModel
    {
        [Key]
        public int ID { get; set; }
        public int pid { get; set; }
        public string sag_sig_aciklama { get; set; }

        public string tur { get; set; }
        public string hastalik_aciklama { get; set; }

        public string ilac_bilgisi { get; set; }

        


        [ForeignKey("pid")]
        public PersonelModel PersonModel { get; set; }


    }
}