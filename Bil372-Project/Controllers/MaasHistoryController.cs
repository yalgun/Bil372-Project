using Bil372_Project.Data;
using Bil372_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers
{
    public class MaasHistoryController : Controller
    {
        public static int? LoggedUserID;

        private DatabaseContext DbContext = new DatabaseContext();

        //GET Salary
        public ActionResult Maas(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Login", "Login");
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
