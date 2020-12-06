using Bil372_Project.Data;
using Bil372_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers
{
    public class LearnDevelopmentController : Controller
    {
        // GET: LearnDevelopment
        private DatabaseContext DbContext = new DatabaseContext();
        public ActionResult LearnDevelopment()
        {
            return View();
        }
        public ActionResult Sertificate()
        {
            var viewModel = new SertifikaViewModel();
            viewModel.SertifikaModels = DbContext.SertifikaModels.ToList();

            ViewData["Message"] = viewModel;
            
            return View(viewModel);
        }

        public ActionResult AddSertificate()
        {
            return View();
        }

        public ActionResult AddNewSertificate(SertifikaModel sertifikamodel)
        {

            if (!ModelState.IsValid)
            {
                return Sertificate();
            }
            DbContext.SertifikaModels.Add(sertifikamodel);
            DbContext.SaveChanges();
            return RedirectToAction("Sertificate", "LearnDevelopment");
        }


        public ActionResult DeleteSertificate(int? id) {
            if (id == null)
            {
                return RedirectToAction("Login", "Login");
            }
            DbContext.SertifikaModels.Remove(DbContext.SertifikaModels.Find(id));
            DbContext.SaveChanges();

            return RedirectToAction("Sertificate", "LearnDevelopment");

        }


    }
}