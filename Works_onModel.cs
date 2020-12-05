using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class Works_onModel
    {
        [Key]
        public int ID { get; set; }
        public int personel_id { get; set; }
        public int project_id { get; set; }



        [ForeignKey("personal_id")]
        public PersonelModel PersonelModel { get; set; }

        [ForeignKey("project_id")]
        public ProjectModel ProjectModel { get; set; }





    }
}