using RentARabla.Contexts;
using RentARabla.Enums;
using RentARabla.Helpers;
using RentARabla.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentARabla.Controllers
{
    public class RentalsController : Controller
    {
        private RentARablaDBContext db = new RentARablaDBContext();
        private RentalsSearch _search = new RentalsSearch();
        // GET: Rentals
        public ActionResult Index()
        {
            //var result = (from rental in db.Rentals
            //              join car in db.Cars on rental.Car.Id equals car.Id
            //              where rental.RentDate <= DateTime.Now && rental.ReturnDate > DateTime.Now
            //              select new RentalsSearch
            //              {
            //                  Id = rental.Id,
            //                  RentDate = rental.RentDate,
            //                  ReturnDate = rental.ReturnDate,
            //                  PricePerDay = car.PricePerDay,
            //                  ManufactureDate = car.ManufactureDate,
            //                  FuelType = car.FuelType,
            //                  Type = car.Type,
            //                  Brand = car.Brand,
            //                  Model = car.Model
            //              });
            return View(_search);
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rentals/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rentals/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rentals/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult SelectType(string carType)
        {
            var results = new List<string>();
            if(carType != String.Empty && carType != null)
            {
                results = GetModelsByType(carType);
            }
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        private List<string> GetModelsByType(string carType)
        {
            var carsByType = db.Types.Where(x => x.Value == carType);
            return new List<string> {"1","2" };
        }

    }
}
