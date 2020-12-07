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
    public class SalaryListController : Controller
    {
        private DatabaseContext DbContext = new DatabaseContext();

        public ActionResult Index()
        {
            var viewModel = new SalaryViewModel();

            viewModel.SalaryModels = DbContext.SalaryModels.ToList();

            ViewData["Message"] = DbContext.SalaryModels.ToList();


            var LD = DbContext.SalaryModels.Include(c => c.PersonModel).ToList();


            return View(LD);

        }
    }
}
