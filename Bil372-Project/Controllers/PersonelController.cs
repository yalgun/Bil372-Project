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

        public ActionResult Personel_proje(int? id) {
            id = LoggedUserID;
            if (id == null)
            {
                return RedirectToAction("Login", "Login");
            }


            List<Works_onModel> workson = DbContext.Works_onModels.Where(x=> x.personel_id==id).ToList();
            List<ProjectModel> project = DbContext.ProjectModels.ToList();
            List<ProjectModel> newproject = new List<ProjectModel> ();

            foreach (var value in workson)
            {
                newproject.Add(project.Where(x=>x.pid==value.project_id).FirstOrDefault());
            }


            return View(newproject);

        }


    }
}