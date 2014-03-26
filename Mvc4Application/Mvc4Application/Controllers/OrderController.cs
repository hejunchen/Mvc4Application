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
    public class OrderController : Controller
    {

        //
        // GET: /Order/
        public ActionResult Index(int id)
        {
            return View((new OrderBL()).GetOrdersBySalesPersonID(id));
        }

        public ActionResult Details(int id)
        {
            return View((new OrderBL()).GetOneOrderByOrderID(id));
        }

    }
}
