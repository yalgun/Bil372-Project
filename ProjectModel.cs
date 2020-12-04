using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bil372_Project.Models
{
    public class ProjectModel
    {
        [Key]
        public int pid { get; set; }
        public string p_adı { get; set; }
        public int dno { get; set; }


        [ForeignKey("dno")]

        public Department Deparment { get; set; }


    }
}