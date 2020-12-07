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
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT a.PersonName, a.PersonSurname, b.sag_sig_aciklama, b.tur, b.hastalik_aciklama, b.ilac_bilgisi, b.ID FROM [dbo].[Benef_ManModel] AS b, [dbo].[Personel] AS a WHERE b.pid = a.ID", sqlCon);
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

        public ActionResult Edit(int ID)
        {
            Benef_ManModel Izin = new Benef_ManModel();
            DataTable dtable = new DataTable();
            
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM [dbo].[Benef_ManModel] WHERE ID ='" + ID + "'";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.Fill(dtable);
                if (dtable.Rows.Count == 1)
                {
                    Izin.ID = (int)dtable.Rows[0][0];
                    Izin.pid = (int)dtable.Rows[0][1];
                    Izin.sag_sig_aciklama = dtable.Rows[0][2].ToString();
                    Izin.tur = dtable.Rows[0][3].ToString();
                    Izin.hastalik_aciklama= dtable.Rows[0][4].ToString();
                    Izin.ilac_bilgisi= dtable.Rows[0][5].ToString();
                    ViewBag.Persons = new SelectList(DbContext.Personel.ToList(), "ID", "username", Izin.pid);
                    return View(Izin);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Benef_ManModel BenefitManagement)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE [dbo].[Benef_ManModel] SET pid = '" + BenefitManagement.pid + "', sag_sig_aciklama = '" + BenefitManagement.sag_sig_aciklama+ "', hastalik_aciklama = '" + BenefitManagement.hastalik_aciklama  + "', tur = " + BenefitManagement.tur + " ilac_bilgisi = '" + BenefitManagement.ilac_bilgisi + "' WHERE ID = "+ BenefitManagement.ID;
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("IzinGiris");
        }
    }
}