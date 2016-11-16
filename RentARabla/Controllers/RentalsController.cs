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

        
        public ActionResult Index()
        {
            ViewBag.IsAdmin = false;

            var search = new RentalsSearch();

            var cars = db.Cars.Where(x => x.IsRented == false).ToList();
            search.Cars = cars;

            search.CarTypeList = new SelectList(db.Types.ToList(), "Id", "Value");

            return View(search);
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



        public ActionResult SelectType(int carType)
        {
            var results = new List<CarBrand>();
            if(carType != null && carType != 0)
            {
                results = GetModelsByType(carType);
            }
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        private List<CarBrand> GetModelsByType(int carType)
        {

            var link = db.l_CarTypesBrands;
            var brands = db.Models.Select(x => x.CarBrand);
            var query = from b in brands
                        join l in link on b.Id equals l.CarBrandId.Id
                        where l.CarTypeId.Id == carType
                        select new { BrandId = b.Id, BrandValue = b.Value };

            return db.Models.Select(x => x.CarBrand).ToList();
        }

    }
}
