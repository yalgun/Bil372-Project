using Bil372_Project.Data;
using Bil372_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers
{
    public class LoginController : Controller
    {
        private DatabaseContext DbContext = new DatabaseContext();
        

        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult Login(PersonelModel personelModel) {

            if (!ModelState.IsValid)
            {
                return LoginPage();
            }

            string username = personelModel.email;
            string parola = personelModel.parola;

            var viewModel = new PersonelViewModel();
            viewModel.Personel = DbContext.Personel.ToList();
            var result = DbContext.Personel.Select(x => new PersonelModel
            {
                username = x.email,
                parola = x.parola

            });

            var person = DbContext.Personel.Where(x => x.email == personelModel.email && x.parola == personelModel.parola).FirstOrDefault();

            if (person != null) {
                string personelusername = personelModel.email;
                string personelparola =personelModel.parola;

                Session["ID"] = person.ID;
                var PID = (int)Session["ID"];

                return RedirectToAction("PersonelInformation", "Personel", new {id= PID });
            }

            return RedirectToAction("LoginPage", "Login");
        }

    }
}