using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Fin_ManModel
    {
        [Key]
        public int ID { get; set; }
        public int pid { get; set; }
        public int tazminat { get; set; }
        public int ikramiye { get; set; }

        


        [ForeignKey("pid")]
        public PersonelModel PersonModel { get; set; }


    }
}