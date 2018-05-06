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

            List<MarkerDTO> resultreturn = new List<MarkerDTO>();
             var result = data.GetMarkersOfType(type);
            foreach (var item in result)
            {
                MarkerDTO current = new MarkerDTO()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Lat = item.Lat,
                    Lng = item.Lng,
                    Contacts = item.Contacts.Select(x => x.Name).ToArray()
                };
                resultreturn.Add(current);
            }
            return Json(resultreturn, JsonRequestBehavior.AllowGet);
        }
      
    }
}