using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Bil372_Project.Models;
using System.Configuration;

namespace Bil372_Project.Data
{
    public class DatabaseContext: DbContext
    {
        public static string conn = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        public DatabaseContext(): base(conn)
        {
        }

        public IDbSet<Department> Departmes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
        }
    }
}