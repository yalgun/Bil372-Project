using Bil372_Project.Data;
using Bil372_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers
{
    public class RegisterController : Controller
    {
        private DatabaseContext DbContext = new DatabaseContext();

        public ActionResult Reg()
        {
            return View ();
        }

        public ActionResult Register(PersonelModel personelModel)
        {

            if (!ModelState.IsValid)
            {
                return Reg();
            }

            DbContext.Personel.Add(personelModel);
            DbContext.SaveChanges();

            return RedirectToAction("LoginPage", "Login");
        }
    }
}
