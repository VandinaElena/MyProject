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
    public class PassengersController : Controller
    {
        private IUnitofWork UnitOfWork = new UnitofWork();
        private IRepository<Passenger> PassengerRepository;
        private PassengersWithFlightsService PassengersWithFlightsService;

        public PassengersController()
        {
            this.PassengerRepository = UnitOfWork.PassageList;
            this.PassengersWithFlightsService = new PassengersWithFlightsService();
        }
        // GET: Passengers
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        //All passengers
        [Authorize]
        public PartialViewResult GetPassengers()
        {
            var passengers = PassengerRepository.GetAll().ToList();

            return PartialView(passengers);
        }
        [Authorize]
        public PartialViewResult GetPassengersWithFlights()
        {
            var passengers = PassengersWithFlightsService.FindPassengersWithFlights().ToList();
       
            return PartialView(passengers);
        }
       

        [Authorize]
        public PartialViewResult ChangeData(int id, string lastName)
        {
            IEnumerable<Passenger> passengers = PassengerRepository.GetAll();
            var passenger = passengers.Where(p => p.Id == id).Single();
            
                passenger.LastName= lastName;
            PassengerRepository.Update(passenger);
            return PartialView("GetPassengers", passengers);
        }
        [Authorize]
        public ActionResult FindByPassportNumber(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pasNum = id.ToLower();
            var passenger = PassengerRepository.Search(c => c.PassportNumber.ToLower() == id).ToList();
            return PartialView(passenger);
        }
        // GET: Passengers/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var passenger = PassengerRepository.Get(id);
            if (passenger != null)
            {
                return View(passenger);
            }
            return HttpNotFound();
        }

        // GET: Passengers/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,sex,DateOfBirth,Nationality,PassportNumber")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                PassengerRepository.Insert(passenger);

                return RedirectToAction("Index");
            }
            return View(passenger);
        }

        // GET: Passengers/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var passenger = PassengerRepository.Get(id);
            if (passenger != null)
            {
                return View(passenger);
            }
            return HttpNotFound();
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,sex,DateOfBirth,Nationality,PassportNumber")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                PassengerRepository.Update(passenger);
                return RedirectToAction("Index");
            }
            return View(passenger);
        }

        // GET: Passengers/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var passenger = PassengerRepository.Get(id);
            if (passenger != null)
            {
                return View(passenger);
            }
            return HttpNotFound();
        }
        [Authorize]
        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var passenger = PassengerRepository.Get(id);
            PassengerRepository.Delete(passenger);
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
