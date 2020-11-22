using Bil372_Project.Data;
using Bil372_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext DbContext;

        public HomeController()
        {
            DbContext = new DatabaseContext();
        }

        public ActionResult Index()
        {
            var viewModel = new DepartmentViewModel();
            viewModel.Departments = DbContext.Departmes.ToList();
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}