using Bil372_Project.Data;
using Bil372_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers
{
    public class PersonelController : Controller
    {
        public static int? LoggedUserID;

        private DatabaseContext DbContext = new DatabaseContext();
        // GET: Personel
        public ActionResult PersonelInformation(int? id)
        {
            

            if (id == null) {
                return RedirectToAction("Login", "Login");
            }
            LoggedUserID = id;
            var person = DbContext.Personel.Where(x => x.ID == id ).FirstOrDefault();
            var departman = DbContext.Departmes.Where(x => x.DepartmentID == person.dno).FirstOrDefault();
            PersonelModel personelModel = (PersonelModel)person;
            Department dept = (Department)departman;

            ViewData["Message"] = personelModel;
            ViewData["departman"] = dept;

            return View();
        }

        public ActionResult Personel_proje(int?id) {

            if (id == null)
            {
                return RedirectToAction("Login", "Login");
            }

            LoggedUserID = id;
            var workson = DbContext.Works_onModels.Where(x => x.personel_id == id).FirstOrDefault();
            var proje = DbContext.ProjectModels.Where(x => x.pid == workson.project_id).FirstOrDefault();
            ProjectModel projectModel = (ProjectModel) proje;
           
            ViewData["Projeler"] = proje;
           

            return View();

        }


    }
}