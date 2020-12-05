using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Acik_PozisyonModel
    {
        [Key]
        public int ID { get; set; }
        public string açıklama { get; set; }
        public string meslek { get; set; }
        public string iş_tanımı { get; set; }

    }
}