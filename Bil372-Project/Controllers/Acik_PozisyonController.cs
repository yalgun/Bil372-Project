using Bil372_Project.Data;
using Bil372_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers

{
    public class Acik_PozisyonController : Controller
     {
    private DatabaseContext DbContext = new DatabaseContext();
    // GET: Acik_Pozisyon
    public ActionResult Acik_Pozisyon()
    {
          
        var viewModel = new Acik_PozisyonViewModel();
        viewModel.Acik_PozisyonModels = DbContext.Acik_PozisyonModels.ToList();

        ViewData["Message"] = viewModel;

        return View(viewModel);
    }


        public ActionResult DeletePosition(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Login", "Login");
            }
            DbContext.Acik_PozisyonModels.Remove(DbContext.Acik_PozisyonModels.Find(id));
            DbContext.SaveChanges();

            return RedirectToAction("Acik_Pozisyon", "Acik_Pozisyon");

        }


        public ActionResult AddPosition()
        {
            return View();
        }


        public ActionResult AddNewPosition(Acik_PozisyonModel acikpozisyonmodel)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Acik_Pozisyon", "Acik_Pozisyon");
            }
            DbContext.Acik_PozisyonModels.Add(acikpozisyonmodel);
            DbContext.SaveChanges();
            return RedirectToAction("Acik_Pozisyon", "Acik_Pozisyon");
        }




    }
}








