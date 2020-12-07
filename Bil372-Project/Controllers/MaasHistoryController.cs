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
    public class MaasHistoryController : Controller
    {
        public static int? LoggedUserID;

        private DatabaseContext DbContext = new DatabaseContext();

       
        public static string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        //GET Salary
        public ActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * FROM SalaryModel", sqlCon);
                sqlDA.Fill(dataTable);
            }
            return View(dataTable);
        }
        public ActionResult Maas(int? id)
        {
            if (id == null && PersonelController.LoggedUserID == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if( id == null)
            {
                id = PersonelController.LoggedUserID;
            }
            LoggedUserID = id;
            var person = DbContext.Personel.Where(x => x.ID == id).FirstOrDefault();
            var salary = DbContext.SalaryModels.Where(x => x.pid == person.ID).FirstOrDefault();
            PersonelModel personelModel = (PersonelModel)person;
            SalaryModel maas = (SalaryModel)salary;

            ViewData["Message"] = personelModel;
            ViewData["salary"] = maas;

            return View ();
        }
    }
}
