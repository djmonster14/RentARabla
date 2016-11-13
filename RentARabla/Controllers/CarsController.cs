using RentARabla.Contexts;
using RentARabla.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RentARabla.Controllers
{
    public class CarsController : Controller
    {
        private RentARablaDBContext db = new RentARablaDBContext();
        // GET: Cars
        public ActionResult Index()
        {
            return View(db.Cars);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create([Bind(Include = "PricePerDay,ManufactureDate,FuelType,Type,Brand,Model")] Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Cars.Add(car);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PricePerDay,ManufactureDate,FuelType,Type,Brand,Model")] Car car)
        {
                if (ModelState.IsValid)
                {
                    db.Entry(car).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected new void Dispose()
        {
            if (db != null)
                db.Dispose();
            base.Dispose();
        }
    }
}
