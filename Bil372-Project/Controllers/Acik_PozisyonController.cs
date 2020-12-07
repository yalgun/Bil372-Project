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

  }
}








