﻿using Bil372_Project.Data;
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

        private DatabaseContext DbContext = new DatabaseContext();
        // GET: Personel
        public ActionResult PersonelInformation(int? id)
        {


            if (id == null) {
                return RedirectToAction("Login", "Login");
            }
            var person = DbContext.Personel.Where(x => x.ID == id ).FirstOrDefault();
            PersonelModel personelModel = (PersonelModel)person;

            ViewData["Message"] = personelModel;

            return View();
        }
    }
}