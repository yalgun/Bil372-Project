using Bil372_Project.Data;
using Bil372_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers
{
    public class AdminController : Controller
    {
        private DatabaseContext DbContext = new DatabaseContext();
        // GET: Admin
        public ActionResult AdminLearningProfDevelopment()
        {

            var viewModel = new PersonelViewModel();
            viewModel.Personel = DbContext.Personel.ToList();
            ViewData["Personel"] = viewModel;
            dynamic mymodel = new ExpandoObject();
            mymodel.Personel = viewModel.Personel;

            var Ldevelopment = DbContext.Learn_DevelopmentModels.ToList();
            mymodel.Ldevelopment = Ldevelopment;


            var LD = DbContext.Learn_DevelopmentModels.Include(c => c.Person).Include(c=>c.Sertifika).ToList();





            return View(LD);

        }

        public ActionResult AddNewLearningProfDevelopment() {

            ViewBag.Persons = new SelectList(DbContext.Personel.ToList(), "ID", "PersonName", "PersonSurname");
            ViewBag.Sertificate = new SelectList(DbContext.SertifikaModels.ToList(), "ID", "sertifika_adi");
            return View();
        }

        [HttpPost]
        public ActionResult getSelectedValue() {


            var person = Request.Form["Persons"];
            var sertificate= Request.Form["Sertificate"];

            int pId= Int16.Parse(person);
            int sId = Int16.Parse(sertificate);
            DbContext.Learn_DevelopmentModels.Add(new Learn_DevelopmentModel
            {
                person_id = pId,
                sertifika_id = sId
            });
            DbContext.SaveChanges();

            Learn_DevelopmentModel ld = new Learn_DevelopmentModel();

            


            return RedirectToAction("AdminLearningProfDevelopment", "Admin");
        }

        public ActionResult DeleteLearnDevelopment(int? id) {
            if (id == null)
            {
                return RedirectToAction("AdminLearningProfDevelopment", "Admin");
            }
            DbContext.Learn_DevelopmentModels.Remove(DbContext.Learn_DevelopmentModels.Find(id));
            DbContext.SaveChanges();

            return RedirectToAction("AdminLearningProfDevelopment", "Admin");
        }
    }
}