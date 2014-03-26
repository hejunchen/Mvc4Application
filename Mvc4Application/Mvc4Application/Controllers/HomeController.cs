using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Mvc4Helper;

namespace Mvc4Application.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public ViewResult Video()
        {



            return View();


            ////get a list of MVC video file objects
            //DirectoryInfo di = new DirectoryInfo(Config.MVCVideoPath);          //get video folder
            //FileInfo[] files = di.GetFiles();                                   //get all video files
            //List<FileInfo> videos = files.OrderBy(x => x.Name).ToList();        //get sorted video collection
            //return View(videos);
        }

        public ViewResult About()
        {
            return View();
        }


        public ViewResult WebAPI()
        {
            return View();
        }


    }
}
