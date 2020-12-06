﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Project.Controllers
{
    public class BenefitManagementController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        // GET: BenefitManagement
        public ActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * FROM [dbo].[Benef_ManMode]",sqlCon);
                sqlDA.Fill(dataTable);
            }

            return View(dataTable);
        }
    }
}