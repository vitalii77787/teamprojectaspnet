using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teamprojectaspnet.DAL;

namespace Teamprojectaspnet.Controllers
{
    public class HomeController : Controller
    {
        DAL.DAL data = new DAL.DAL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult GetAllTypes()
        {
            var result = data.GetAllPlaceTypes();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}