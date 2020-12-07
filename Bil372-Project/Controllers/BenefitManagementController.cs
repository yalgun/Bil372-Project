using Bil372_Project.Data;
using Bil372_Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers
{
    public class BenefitManagementController : Controller
    {
        private DatabaseContext DbContext = new DatabaseContext();
        public static string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        // GET: BenefitManagement
        public ActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * FROM [dbo].[Benef_ManModel]",sqlCon);
                sqlDA.Fill(dataTable);
            }

            return View(dataTable);
        }
        public ActionResult Delete(int ID)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM [dbo].[Benef_ManMode] WHERE ID = '" + ID + "'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();

            }
            return RedirectToAction("IzinGiris");
        }

        public ActionResult Create()
        {
            ViewBag.Persons = new SelectList(DbContext.Personel.ToList(), "ID", "username", "PersonSurname");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Benef_ManModel BenefitManagement )
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO [dbo].[Benef_ManModel] VALUES(" + BenefitManagement.pid + ", '"+ BenefitManagement.sag_sig_aciklama + 
                    "', '" + BenefitManagement.tur + "', '" + BenefitManagement.hastalik_aciklama + "', '" + 
                    BenefitManagement.ilac_bilgisi + "')";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}