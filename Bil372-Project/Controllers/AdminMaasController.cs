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
    public class AdminMaasController : Controller
    {
        private DatabaseContext DbContext = new DatabaseContext();
        public static string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        public ActionResult AdminMaasPage()
        {
            ViewBag.Persons = new SelectList(DbContext.Personel.ToList(), "ID", "username", "PersonSurname");
            return View();
        }

        [HttpPost]
        public ActionResult AdminMaasPage(SalaryModel salary)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO [dbo].[SalaryModel] VALUES(" + salary.pid + ", '" + salary.miktar +
                    "', '" + salary.tarih + "')";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("AdminMaasPage");
        }


    }
}
