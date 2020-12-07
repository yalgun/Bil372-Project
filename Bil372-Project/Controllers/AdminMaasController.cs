﻿using Bil372_Project.Data;
using Bil372_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers
{
    public class AdminMaasController : Controller
    {
        private DatabaseContext DbContext = new DatabaseContext();


        public ActionResult AdminMaasPage()
        {
            ViewBag.Persons = new SelectList(DbContext.Personel.ToList(), "ID", "username", "PersonSurname");
            return View();
        }

        [HttpPost]
        public ActionResult getSelectedValue(SalaryModel salaryModel)
        {

            var person = Request.Form["Persons"];

            int pId = Int16.Parse(person);
            // DateTime giris = Request.Form["giris_saati"];
            DbContext.SalaryModels.Add(new SalaryModel
            {
                pid = pId,
                miktar = salaryModel.miktar,
                tarih = salaryModel.tarih
            });
            DbContext.SaveChanges();

            Learn_DevelopmentModel ld = new Learn_DevelopmentModel();

            return RedirectToAction("ListAllSalary", "AdminMaasPage");
        }


        public ActionResult ListAllSalary()
        {
            var viewModel = new SalaryViewModel();

            viewModel.SalaryModels = DbContext.SalaryModels.ToList();

            ViewData["Message"] = DbContext.SalaryModels.ToList();


            var LD = DbContext.SalaryModels.Include(c => c.PersonModel).ToList();


            return View(LD);

        }

        public ActionResult DeleteSalary(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Login", "Login");
            }
            DbContext.SalaryModels.Remove(DbContext.SalaryModels.Find(id));
            DbContext.SaveChanges();

            return RedirectToAction("ListAllTimeAttandance", "AdminMaasPage");

        }




    }
}