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
            List<string> resultreturn = new List<string>();
             var result = data.GetMarkersOfType(type);
            foreach (var item in result)
            {
                var str = item.Name + " " + item.Lat + " " + item.Lng + " ";
                resultreturn.Add(str);
            }
            return Json(resultreturn, JsonRequestBehavior.AllowGet);
        }
      
    }
}