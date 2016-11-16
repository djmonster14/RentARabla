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
    public class ClientsController : Controller
    {
        private RentARablaDBContext db = new RentARablaDBContext();

        public ActionResult Index()
        {
            return View(db.Clients);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Email,Phone,UserName,Password,NationalId")] Client client)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    db.Clients.Add(client);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Phone,UserName,Password,NationalId")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password, int carId)
        {
            if (ModelState.IsValid)
            {
                var user = db.Persons.Where(x => x.UserName == userName && x.Password == password).ToList();
                if (user.Count != 0)
                {
                    if (userName == "admin" && password == "admin")
                    {
                        ViewBag.IsAdmin = true;
                    }
                    else
                    {
                        ViewBag.IsAdmin = false;
                    }
                    TempData["UserName"] = userName;
                    return RedirectToAction("Index", "Rentals");
                }
                else
                    ModelState.AddModelError("", "Incorrect username or password");
            }
            return View();
        }

        public ActionResult Authenticate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(Client model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Clients.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Rentals");
            }
            catch
            {
                return View();
            }
        }
    }
}
