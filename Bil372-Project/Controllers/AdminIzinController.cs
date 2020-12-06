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
    public class AdminIzinController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        // GET: AdminIzin
        public ActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT a.ID, a.pid, b.PersonName, b.PersonSurname, a.aciklama, a.baslangic_t, a.bitis_t, a.gun_sayisi, a.isApprove " +
                    " FROM [dbo].[IzinModel] as a , [dbo].[Personel] as b WHERE a.pid = b.ID ", sqlCon);
                sqlDA.Fill(dataTable);
            }

            return View(dataTable);
        }

        public ActionResult Approve(int ID)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE [dbo].[IzinModel] SET isApprove = '" + 1 + "' WHERE ID = '" + ID + "'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}