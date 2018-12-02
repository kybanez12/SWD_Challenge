using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PotluckWebApp.Models;

namespace PotluckWebApp.Controllers
{
    public class PotlucksController : Controller
    {
        private PotDBEntities db = new PotDBEntities();

        // GET: Potlucks
        public ActionResult Index()
        {
            var potlucks = db.Potlucks.Include(p => p.Member);
            return View(potlucks.ToList());
        }

        // GET: Potlucks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potluck potluck = db.Potlucks.Find(id);
            if (potluck == null)
            {
                return HttpNotFound();
            }
            return View(potluck);
        }

        // GET: Potlucks/Create
        public ActionResult Create()
        {
            ViewBag.Host = new SelectList(db.Members, "Id", "Name");
            return View();
        }

        // POST: Potlucks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Time,Host,Cost")] Potluck potluck)
        {
            if (ModelState.IsValid)
            {
                db.Potlucks.Add(potluck);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Host = new SelectList(db.Members, "Id", "Name", potluck.Host);
            return View(potluck);
        }

        // GET: Potlucks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potluck potluck = db.Potlucks.Find(id);
            if (potluck == null)
            {
                return HttpNotFound();
            }
            ViewBag.Host = new SelectList(db.Members, "Id", "Name", potluck.Host);
            return View(potluck);
        }

        // POST: Potlucks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Time,Host,Cost")] Potluck potluck)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potluck).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Host = new SelectList(db.Members, "Id", "Name", potluck.Host);
            return View(potluck);
        }

        // GET: Potlucks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potluck potluck = db.Potlucks.Find(id);
            if (potluck == null)
            {
                return HttpNotFound();
            }
            return View(potluck);
        }

        // POST: Potlucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Potluck potluck = db.Potlucks.Find(id);
            db.Potlucks.Remove(potluck);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
