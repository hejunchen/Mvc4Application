using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4BusinessLayer;
using Mvc4DataTransfer;
using Mvc4Helper;
using System.Configuration;

namespace Mvc4Application.Controllers
{
    public class EmployeeController : Controller
    {

        //default page
        public ActionResult Index()
        {
            return View((new EmployeeBL()).GetEmployees());
        }


        //display one employee details
        public ActionResult Details(int id)
        {
            return View((new EmployeeBL()).GetOneEmployeeByID(id));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string firstname, string middlename, string lastname, string gender, DateTime birthdate)
        {
            //foreach (string key in fc.AllKeys)
            //{
            //    Response.Write("Key = " + key.ToString() + "            ");
            //    Response.Write("Value = " + fc[key].ToString());
            //    Response.Write("<br />");
            //}

            Response.Write("First Name: " + firstname + "<br />");
            Response.Write("Middle Name: " + middlename + "<br />");
            Response.Write("Last Name: " + lastname + "<br />");
            Response.Write("Gender: " + gender + "<br />");
            Response.Write("Birth Date: " + birthdate.ToShortDateString() + "<br />");

            return View();
        }


    }
}
