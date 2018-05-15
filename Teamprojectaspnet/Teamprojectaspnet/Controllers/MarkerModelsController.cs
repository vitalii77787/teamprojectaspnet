using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teamprojectaspnet.DAL;
using Teamprojectaspnet.Models;
using Teamprojectaspnet.Services;

namespace Teamprojectaspnet.Controllers
{
    public class MarkerModelsController : Controller
    {
        private DAL.DAL data = new DAL.DAL();

        // GET: MarkerModels
        public async Task<ActionResult> Index()
        {
            var resultreturn = MarkerConverter.ConvertToView(await data.GetAllMarker());
            return View(resultreturn);
        }

        // GET: MarkerModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkerModel markerModel = MarkerConverter.MarkerById(await data.GetMarkerByIdAsync((int)id));
            if (markerModel == null)
            {
                return HttpNotFound();
            }
            return View(markerModel);
        }

        // GET: MarkerModels/Create
        public ActionResult Create()
        {
            ViewBag.Logins = data.GetAllLogins();
            ViewBag.Types = data.GetAllPlaceTypes();
            ViewBag.Addresses = data.GetAllAddresses();
            ViewBag.Contacts = data.GetAllContacts();
            return View();
        }

        // POST: MarkerModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Lat,Lng,TypeofMarker,MarkerAddress,MarkerLogin,Contacts")] MarkerModel markerModel)
        {
            if (ModelState.IsValid)
            {
                data.AddNewMarker(markerModel);
                return RedirectToAction("Index");
            }
            return View(markerModel);
        }

        // GET: MarkerModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkerModel markerModel = MarkerConverter.MarkerById(await data.GetMarkerByIdAsync((int)id));
            if (markerModel == null)
            {
                return HttpNotFound();
            }
            return View(markerModel);
        }

        // POST: MarkerModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Description,Lat,Lng,TypeofMarker,MarkerAddress,MarkerLogin")] MarkerModel markerModel)
        {
            if (ModelState.IsValid)
            {
                await data.UpdateMarker(markerModel);
                return RedirectToAction("Index");
            }
            return View(markerModel);
        }

        // GET: MarkerModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkerModel markerModel = MarkerConverter.MarkerById(await data.GetMarkerByIdAsync((int)id));
            if (markerModel == null)
            {
                return HttpNotFound();
            }
            return View(markerModel);
        }

        // POST: MarkerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
           await data.DeleteMarker(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
