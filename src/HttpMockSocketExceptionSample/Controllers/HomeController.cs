using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HttpMockSocketExceptionSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string result;
            try
            {
                using (var webClient = new WebClient())
                {
                    result =  webClient.DownloadString("http://localhost:9009/Stub");
                }
            }
            catch (WebException)
            {
                result = "NOT STUBBED";
            }
            ViewBag.Message = result;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
