using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD:Bil372-Project/Controllers/AdminController.cs

namespace Bil372_Project.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
=======
using Bil372_Project.Data;
using Bil372_Project.Models;

namespace Bil372_Project.Controllers
{
    public class RegisterController : Controller
    {

        private DatabaseContext DbContext = new DatabaseContext();

        public ActionResult RegisterPage()
        {
            return View ();
        }

        public ActionResult Register(PersonelModel personelModel)
        {

            if (!ModelState.IsValid)
            {
                return RegisterPage();
            }

            DbContext.Personel.Add(personelModel);
            DbContext.SaveChanges();

            return RedirectToAction("LoginPage", "Login");
>>>>>>> ea655b2... Register page back end added:Bil372-Project/Controllers/RegisterController.cs
        }
    }
}