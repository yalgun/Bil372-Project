using Bil372_Project.Data;
using Bil372_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers
{
    public class ProjectController : Controller
    {

        private DatabaseContext DbContext = new DatabaseContext();
        // GET: Project
        public ActionResult ListProjects()
        {
            var viewModel = new DepartmentViewModel();
            viewModel.Departments = DbContext.Departmes.ToList();
            List<ProjectModel> project = DbContext.ProjectModels.ToList();
            List<Department> newproject = new List<Department>();
            dynamic mymodel = new ExpandoObject();
            foreach (var value in project)
            {
                int id = value.dno;
                newproject.Add(DbContext.Departmes.Find(id));
            }
            mymodel.Project = project;
            mymodel.Department = newproject;

            return View(mymodel);
        }

        public ActionResult AddNewProject()
        {

            ViewBag.Persons = new SelectList(DbContext.Personel.ToList(), "ID", "PersonName", "PersonSurname");
            ViewBag.Department = new SelectList(DbContext.Departmes.ToList(), "DepartmentID", "DepartmentName");
            return View();
        }


        [HttpPost]
        public ActionResult getSelectedValue()
        {


            var person = Request.Form["p_adı"];
            var department = Request.Form["Department"];

            int sId = Int16.Parse(department);
            DbContext.ProjectModels.Add(new ProjectModel
            {
                p_adı = person.ToString(),
                dno = sId
            });
            DbContext.SaveChanges();

            Learn_DevelopmentModel ld = new Learn_DevelopmentModel();


            return RedirectToAction("ListProjects", "Project");
        }


        public ActionResult AddNewProjectToPerson() {

            ViewBag.Persons = new SelectList(DbContext.Personel.ToList(), "ID", "PersonName", "PersonSurname");
            ViewBag.Project = new SelectList(DbContext.ProjectModels.ToList(), "pid", "p_adı");

            return View();
        }


        [HttpPost]
        public ActionResult SetPersonToProject()
        {


            var person = Request.Form["Persons"];
            var project = Request.Form["Project"];
            int pId= Int16.Parse(person);
            int sId = Int16.Parse(project);
            DbContext.Works_onModels.Add(new Works_onModel
            {
                personel_id = pId,
                project_id = sId
            });
            DbContext.SaveChanges();



            return RedirectToAction("ListProjects", "Project");
        }


        public ActionResult DeleteProject(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Login", "Login");
            }
            DbContext.ProjectModels.Remove(DbContext.ProjectModels.Find(id));
            DbContext.SaveChanges();

            return RedirectToAction("ListProjects", "Project");
        }

    }
}