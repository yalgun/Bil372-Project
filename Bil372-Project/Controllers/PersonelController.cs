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
    public class PersonelController : Controller
    {
        public static int? LoggedUserID;
        public static string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        private DatabaseContext DbContext = new DatabaseContext();
        // GET: Personel
        public ActionResult PersonelInformation(int? id)
        {


            if (id == null) {
                return RedirectToAction("Login", "Login");
            }
            LoggedUserID = id;
            var person = DbContext.Personel.Where(x => x.ID == id).FirstOrDefault();
            var departman = DbContext.Departmes.Where(x => x.DepartmentID == person.dno).FirstOrDefault();
            PersonelModel personelModel = (PersonelModel)person;
            Department dept = (Department)departman;

            ViewData["Message"] = personelModel;
            ViewData["departman"] = dept;

            return View();
        }

        public ActionResult Personel_proje(int? id) {
            id = LoggedUserID;
            if (id == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var viewModel = new ProjectViewModel();

            List<Works_onModel> workson = DbContext.Works_onModels.Where(x=> x.personel_id==id).ToList();
            List<ProjectModel> project = DbContext.ProjectModels.ToList();
            List<ProjectModel> newproject = new List<ProjectModel> ();

            foreach (var value in workson)
            {
                newproject.Add(project.Where(x=>x.pid==value.project_id).FirstOrDefault());
                viewModel.ProjectModels.Add((project.Where(x => x.pid == value.project_id).FirstOrDefault()));
            }


            return View(viewModel);

        }

        public ActionResult IzinGiris()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * FROM [dbo].[IzinModel] WHERE pid = '" + (int)LoggedUserID + "'", sqlCon);
                sqlDA.Fill(dataTable);
            }

            return View(dataTable);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new IzinModel());
        }

        [HttpPost]
        public ActionResult Create(IzinModel Izin)
        {
            int toplamGun = (int)(Izin.bitis_t - Izin.baslangic_t).TotalDays;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO [dbo].[IzinModel] VALUES( " + LoggedUserID + ",'" + Izin.aciklama + "', '" +
                    Izin.baslangic_t.ToString("yyyy-MM-dd") + "', '" + Izin.bitis_t.ToString("yyyy-MM-dd") + "', " + toplamGun + ", " + 0 + ")";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("IzinGiris");
        }

        public ActionResult Delete(int ID)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM [dbo].[IzinModel] WHERE ID = '" + ID + "'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();

            }
            return RedirectToAction("IzinGiris");
        }

        public ActionResult Edit(int ID)
        {
            IzinModel Izin = new IzinModel();
            DataTable dtable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM [dbo].[IzinModel] WHERE ID ='" + ID + "'";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.Fill(dtable);
                if (dtable.Rows.Count == 1)
                {
                    Izin.ID = (int)dtable.Rows[0][0];
                    Izin.pid = (int)dtable.Rows[0][1];
                    Izin.aciklama = dtable.Rows[0][2].ToString();
                    Izin.baslangic_t = Convert.ToDateTime(dtable.Rows[0][3].ToString());
                    Izin.bitis_t = Convert.ToDateTime(dtable.Rows[0][4].ToString());
                    Izin.gun_sayisi = (int)dtable.Rows[0][5];
                    Izin.isApprove = (int)dtable.Rows[0][6];
                    return View(Izin);
                }
            }
            return RedirectToAction("IzinGiris");
        }

        [HttpPost]
        public ActionResult Edit(IzinModel Izin)
        {
            int toplamGun = (int)(Izin.bitis_t - Izin.baslangic_t).TotalDays;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE [dbo].[IzinModel] SET aciklama = '" + Izin.aciklama + "', baslangic_t = '" + Izin.baslangic_t.ToString("yyyy-MM-dd") + "', bitis_t = '" + Izin.bitis_t.ToString("yyyy-MM-dd") + "', gun_sayisi = " + toplamGun + ", isApprove = " + 0 + " WHERE ID = " + Izin.ID;
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("IzinGiris");
        }

        public ActionResult BenefitManagement()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * FROM [dbo].[Benef_ManModel] WHERE pid = '" + (int)LoggedUserID + "'", sqlCon);
                sqlDA.Fill(dataTable);
            }

            return View(dataTable);
        }



        public ActionResult Sertifikalarim() {

            int? id = LoggedUserID;
            if (id == null) {
                return RedirectToAction("Login", "Login");
            }
            

            List<Learn_DevelopmentModel> learn_Developments = DbContext.Learn_DevelopmentModels.Where(x => x.person_id == id).ToList();
            List<SertifikaModel> sertificate = DbContext.SertifikaModels.ToList();
            List<SertifikaModel> newsertificate = new List<SertifikaModel>();
            var viewModel = new SertifikaViewModel();

            foreach (var value in learn_Developments)
            {
                viewModel.SertifikaModels.Add((sertificate.Where(x => x.ID == value.sertifika_id).FirstOrDefault()));
            }

            return View(viewModel);



        }
    }
}