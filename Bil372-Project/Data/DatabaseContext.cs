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
        public IDbSet<PersonelModel> Personel { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DbContext>(new DropCreateDatabaseIfModelChanges<DbContext>());

            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<PersonelModel>().ToTable("Personel");

        }


    }
}