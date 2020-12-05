using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class SalaryModel
    {
        [Key]
        public int sid { get; set; }
        public int pid { get; set; }
        public int miktar { get; set; }
        public DateTime tarih { get; set; }


        [ForeignKey("pid")]
        public PersonelModel PersonModel { get; set; }


    }
}