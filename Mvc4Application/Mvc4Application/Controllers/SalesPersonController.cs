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
    public class SalesPersonController : Controller
    {

        //
        // GET: /SalesPerson/

        public ActionResult Index()
        {
            return View((new SalesPersonBL()).GetSalesPersons());
        }


        public ActionResult Details(int id)
        {
            return View((new SalesPersonBL()).GetOneSalesPersonByID(id));
        }


    }
}
