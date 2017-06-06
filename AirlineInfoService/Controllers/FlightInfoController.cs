using AirlineContracts;
using AirlineModels;
using AirlineModels.Entities;
using AirlineServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AirlineInfoService.Controllers
{
    public class FlightInfoController : Controller
    {
        private IUnitofWork UnitOfWork = new UnitofWork();
        private IRepository<FlightInfo> FlightRepository;
        private FlightInfoService FlightInfoService;
        private FindFlightByStatusService FindFlightByStatusService;

        public FlightInfoController()
        {
            this.FindFlightByStatusService = new FindFlightByStatusService();
            this.FlightInfoService = new FlightInfoService();
            this.FlightRepository = UnitOfWork.FlightInfo;
        }

        // GET: FlightInfo
        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<FlightInfo> flights = FlightRepository.GetAll();
            return View(flights);
        }
        [ChildActionOnly]
        public ActionResult FlightsByStatus()
        {
            return PartialView("FlightsByStatus");
        }
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flight = FlightRepository.Get(id);
            if (flight != null)
            {
                return View(flight);
            }
            return HttpNotFound();

        }
        [Authorize]
        [Route("{passenger}")]
     //Find By Passenger's Last Name
        public ActionResult Find(string id)
        {
            string newId = id.ToLower();
            var flight = FlightInfoService.FindFlight(newId);
            return PartialView(flight);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Datetime,FlightNumber,PortOfArrival,Terminal,Flightstatus,Gate")] FlightInfo newflight)
        {
            if (ModelState.IsValid)
            {
                FlightRepository.Insert(newflight);
               
                return RedirectToAction("Index");
            }
            return View(newflight);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flight = FlightRepository.Get(id);
            if (flight != null)
            {
                return View(flight);
            }
            return HttpNotFound();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Datetime,FlightNumber,PortOfArrival,Terminal,Flightstatus,Gate")] FlightInfo flightInfo)
        {
            if (ModelState.IsValid)
            {
                FlightRepository.Update(flightInfo);
                return RedirectToAction("Index");
            }
            return View(flightInfo);
        }
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flight = FlightRepository.Get(id);
            if (flight != null)
            {
                return View(flight);
            }
            return HttpNotFound();

        }
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var flight = FlightRepository.Get(id);
            FlightRepository.Delete(flight);
            return RedirectToAction("Index");

        }
        [AllowAnonymous]
        public ActionResult GetFlightByStatus()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult GetFlightByStatus(FlightInfo model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightStatus status = model.Flightstatus;
            var flights = FindFlightByStatusService.FindFlightByStatus(status);
            return View(flights);
        }
        [AllowAnonymous]
        public ActionResult FindByNumber(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var flights = FlightRepository.Search(c => c.FlightNumber == id).ToList();
            return PartialView(flights);
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