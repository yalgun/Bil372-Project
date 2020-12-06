using Bil372_Project.Data;
using Bil372_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers
{
    public class TimeAttandanceController : Controller
    {
        private DatabaseContext DbContext = new DatabaseContext();
        // GET: TimeAttandance
        public ActionResult AddPersonTimeAttandance()
        {
            ViewBag.Persons = new SelectList(DbContext.Personel.ToList(), "ID", "PersonName", "PersonSurname");
            return View();
        }



        [HttpPost]
        public ActionResult getSelectedValue(Time_AttandanceModel time_AttandanceModel)
        {


            var person = Request.Form["Persons"];

            int pId = Int16.Parse(person);
           // DateTime giris = Request.Form["giris_saati"];
            DbContext.Time_AttandanceModels.Add(new Time_AttandanceModel
            {
                person_id = pId,
                giris_saati = time_AttandanceModel.giris_saati,
                cikis_saati= time_AttandanceModel.cikis_saati
        });
            DbContext.SaveChanges();

            Learn_DevelopmentModel ld = new Learn_DevelopmentModel();




            return RedirectToAction("ListAllTimeAttandance", "TimeAttandance");
        }


        public ActionResult ListAllTimeAttandance() {
            var viewModel = new Time_AttandanceViewModel();
            
            viewModel.Time_att = DbContext.Time_AttandanceModels.ToList();

            ViewData["Message"] = DbContext.Time_AttandanceModels.ToList();


            var LD = DbContext.Time_AttandanceModels.Include(c => c.PersonModel).ToList();


            return View(LD);

        }

        public ActionResult DeleteAttandance(int? id) {
            if (id == null)
            {
                return RedirectToAction("Login", "Login");
            }
            DbContext.Time_AttandanceModels.Remove(DbContext.Time_AttandanceModels.Find(id));
            DbContext.SaveChanges();

            return RedirectToAction("ListAllTimeAttandance", "TimeAttandance");

        }

    }
}