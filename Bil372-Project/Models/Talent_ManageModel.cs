using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Talent_ManageModel
    {
        [Key]
        public int ID { get; set; }
        public string ad{ get; set; }
        public int seviye { get; set; }

        public string aciklama { get; set; }
        public int pid { get; set; }

      

        [ForeignKey("pid")]
        public PersonelModel PersonModel { get; set; }


    }
}