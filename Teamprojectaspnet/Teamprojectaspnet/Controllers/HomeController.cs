using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teamprojectaspnet.DAL;
using Teamprojectaspnet.Services;

namespace Teamprojectaspnet.Controllers
{
    public class HomeController : Controller
    {
        DAL.DAL data = new DAL.DAL();
        public ActionResult Index()
        {
            ViewBag.Types=data.GetAllPlaceTypes();
            return View();
        }

        public ActionResult About()
        {
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
        [HttpPost]
        public JsonResult GetMarkersOfType(string type)
        {
            var resultreturn = MarkerConverter.ConvertToView(data.GetMarkersOfType(type));
            return Json(resultreturn, JsonRequestBehavior.AllowGet);
        }
      
    }
}