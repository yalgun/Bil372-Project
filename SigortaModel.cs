using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class SigortaModel
    {
        [Key]
        public int ID { get; set; }
        public string sig_adı { get; set; }
        public string sig_turu { get; set; }

        public string aciklama { get; set; }
        public int miktar { get; set; }

        public int pid { get; set; }



        [ForeignKey("pid")]
        public PersonelModel PersonModel { get; set; }


    }
}