using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirlineDAL;
using AirlineModels.Entities;
using AirlineContracts;
using AirlineServices;

namespace AirlineInfoService.Controllers
{
    public class DeparturesInfoesController : Controller
    {
        private IUnitofWork UnitOfWork = new UnitofWork();
        private IRepository<DeparturesInfo> DeparturesRepository;

        public DeparturesInfoesController()
        {
            this.DeparturesRepository = UnitOfWork.DeparturesInfo;
        }
        [AllowAnonymous]
        // GET: DeparturesInfoes
        public ActionResult Index()
        {
            IEnumerable<DeparturesInfo> departures = DeparturesRepository.GetAll();
            return View(departures);
        }
        [Authorize]
        // GET: DeparturesInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var departure = DeparturesRepository.Get(id);
            if (departure != null)
            {
                return View(departure);
            }
            return HttpNotFound();
        }
        [Authorize]
        // GET: DeparturesInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeparturesInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Datetime,FlightNumber,Destination,Terminal,Flightstatus,Gate")] DeparturesInfo departuresInfo)
        {
            if (ModelState.IsValid)
            {
                DeparturesRepository.Insert(departuresInfo);

                return RedirectToAction("Index");
            }
            return View(departuresInfo);
        }

        // GET: DeparturesInfoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var departure = DeparturesRepository.Get(id);
            if (departure != null)
            {
                return View(departure);
            }
            return HttpNotFound();
        }

        // POST: DeparturesInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Datetime,FlightNumber,Destination,Terminal,Flightstatus,Gate")] DeparturesInfo departuresInfo)
        {
            if (ModelState.IsValid)
            {
                DeparturesRepository.Update(departuresInfo);
                return RedirectToAction("Index");
            }
            return View(departuresInfo);
        }

        // GET: DeparturesInfoes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var departuresInfo = DeparturesRepository.Get(id);
            if (departuresInfo != null)
            {
                return View(departuresInfo);
            }
            return HttpNotFound();
        }

        // POST: DeparturesInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var departuresInfo = DeparturesRepository.Get(id);
            DeparturesRepository.Delete(departuresInfo);
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult FindByNumber(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var departure = DeparturesRepository.Search(c => c.FlightNumber == id).ToList();
            return PartialView(departure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
