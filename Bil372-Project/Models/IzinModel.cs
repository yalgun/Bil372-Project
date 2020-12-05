using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class IzinModel
    {
        [Key]
        public int ID { get; set; }
        public int pid { get; set; }
        public string aciklama { get; set; }
        public DateTime baslangic_t { get; set; }
        public DateTime bitis_t { get; set; }
        public int gun_sayisi { get; set; }
        public int isApprove { get; set; }



        [ForeignKey("pid")]
        public PersonelModel PersonModel { get; set; }


    }
}