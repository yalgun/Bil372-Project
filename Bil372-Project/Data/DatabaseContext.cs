using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Bil372_Project.Models;
using System.Configuration;

namespace Bil372_Project.Data
{
    public class DatabaseContext : DbContext
    {
        public static string conn = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        public DatabaseContext() : base(conn)
        {
        }

        public IDbSet<Department> Departmes { get; set; }
        public IDbSet<PersonelModel> Personel { get; set; }
        public IDbSet<Acik_PozisyonModel> Acik_PozisyonModels { get; set; }
        public IDbSet<Benef_ManModel> Benef_ManModels { get; set; }
        public IDbSet<Fin_ManModel> Fin_ManModels { get; set; }
        public IDbSet<IzinModel> IzinModels { get; set; }
        public IDbSet<Learn_DevelopmentModel> Learn_DevelopmentModels { get; set; }
        public IDbSet<ProjectModel> ProjectModels { get; set; }
        public IDbSet<SalaryModel> SalaryModels { get; set; }
        public IDbSet<SertifikaModel> SertifikaModels { get; set; }
        public IDbSet<SigortaModel> SigortaModels { get; set; }
        public IDbSet<Talent_ManageModel> Talent_ManageModels { get; set; }
        public IDbSet<Time_AttandanceModel> Time_AttandanceModels { get; set; }
        public IDbSet<Works_onModel> Works_onModels { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DbContext>(new DropCreateDatabaseIfModelChanges<DbContext>());

            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<PersonelModel>().ToTable("Personel");
            modelBuilder.Entity<Acik_PozisyonModel>().ToTable("Acik_PozisyonModel");
            modelBuilder.Entity<Benef_ManModel>().ToTable("Benef_ManModel");
            modelBuilder.Entity<Fin_ManModel>().ToTable("Fin_ManModel");
            modelBuilder.Entity<IzinModel>().ToTable("IzinModel");
            modelBuilder.Entity<Learn_DevelopmentModel>().ToTable("Learn_DevelopmentModel");
            modelBuilder.Entity<ProjectModel>().ToTable("ProjectModel");
            modelBuilder.Entity<SalaryModel>().ToTable("SalaryModel");
            modelBuilder.Entity<SertifikaModel>().ToTable("SertifikaModel");
            modelBuilder.Entity<SigortaModel>().ToTable("SigortaModel");
            modelBuilder.Entity<Talent_ManageModel>().ToTable("Talent_ManageModel");
            modelBuilder.Entity<Time_AttandanceModel>().ToTable("Time_AttandanceModel");
            modelBuilder.Entity<Works_onModel>().ToTable("Works_onModel");

        }
    }
}