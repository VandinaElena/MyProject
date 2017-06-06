using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirlineDAL;
using AirlineModels;
using AirlineContracts;
using AirlineServices;

namespace AirlineInfoService.Controllers
{
    public class FlightPricesController : Controller
    {
        private IUnitofWork UnitOfWork = new UnitofWork();
        private IRepository<FlightPrice> PriceRepo;

        public FlightPricesController()
        {
            this.PriceRepo = UnitOfWork.FlightPricelist;
        }
        private void PopulateFlightNumberDropDownList(object selectedFlight = null)
        {
            var query = PriceRepo.Search(c => c.DeparturesInfo.FlightNumber != null).ToList();
            ViewBag.FlightNumbers = new SelectList(query, "DeparturesInfo.Id", "DeparturesInfo.FlightNumber", selectedFlight);
        }

        public ActionResult Index()
        {
            return View();
        }
        // GET: FlightPrices

        public PartialViewResult GetArrivalsPrices()
        {
            IEnumerable<FlightPrice> prices = PriceRepo.Search(c => c.FlightInfo.FlightNumber != null);
           
            return PartialView( prices);
        }
        public PartialViewResult GetDeparturesPrices()
        {
            var prices = PriceRepo.Search(e => e.DeparturesInfo.FlightNumber != null);
            return PartialView(prices);
        }
        // GET: FlightPrices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var prices = PriceRepo.Get(id);
            if (prices != null)
            {
                return View(prices);
            }
            return HttpNotFound();
        }

        // GET: FlightPrices/Create
        [Authorize]
        public ActionResult Create()
        {
            PopulateFlightNumberDropDownList();
            return View();
        }

        // POST: FlightPrices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public ActionResult Create([Bind(Include = "Id,Price,Class, DeparturesInfo.Id")] FlightPrice flightPrice)
        {
            if (ModelState.IsValid)
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            {
                PriceRepo.Insert(flightPrice);

                return RedirectToAction("Index");
            }
            PopulateFlightNumberDropDownList(flightPrice.DeparturesInfo.Id);
            return View(flightPrice);
        }

        // GET: FlightPrices/Edit/5
        [Authorize]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pricelist = PriceRepo.Get(id);
            if (pricelist != null)
            {
                return View(pricelist);
            }
            PopulateFlightNumberDropDownList(pricelist.DeparturesInfo.Id);
            return HttpNotFound();
        }

        // POST: FlightPrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public ActionResult Edit([Bind(Include = "Id,Price,Class, DeparturesInfo.Id")] FlightPrice flightPrice)
        {
            if (ModelState.IsValid)
            {
                PriceRepo.Update(flightPrice);
                return RedirectToAction("Index");
            }

            return View(flightPrice);
        }

        // GET: FlightPrices/Delete/5
        [Authorize]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flightPrice = PriceRepo.Get(id);
            if (flightPrice != null)
            {
                return View(flightPrice);
            }
            return HttpNotFound();
        }

        // POST: FlightPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]

        public ActionResult DeleteConfirmed(int id)
        {
            var flightPrice = PriceRepo.Get(id);
            PriceRepo.Delete(flightPrice);
            return RedirectToAction("Index");
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
