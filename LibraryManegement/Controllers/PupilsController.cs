using LibraryManegement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace managementApp.Controllers
{
    public class PupilsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: Pupils
        public ActionResult Index()
        {
            return View(db.Pupils.ToList());
        }

        [Authorize]
        // GET: Pupils/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = db.Pupils.Find(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            return View(pupils);
        }

        [Authorize]
        // GET: Pupils/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: Pupils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Author_first_name,Author_middle_name,Author_last_name,Gender,Address,Phone_number,Email")] Pupils pupils)
        {
            if (ModelState.IsValid)
            {
                db.Pupils.Add(pupils);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pupils);
        }

        [Authorize]
        // GET: Pupils/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = db.Pupils.Find(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            return View(pupils);
        }

        [Authorize]
        // POST: Pupils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Author_first_name,Author_middle_name,Author_last_name,Gender,Address,Phone_number,Email")] Pupils pupils)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pupils).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pupils);
        }

        [Authorize]
        // GET: Pupils/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = db.Pupils.Find(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            return View(pupils);
        }

        [Authorize]
        // POST: Pupils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Pupils pupils = db.Pupils.Find(id);
            db.Pupils.Remove(pupils);
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
