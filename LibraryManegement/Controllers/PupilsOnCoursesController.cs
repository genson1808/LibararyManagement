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
    public class PupilsOnCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: PupilsOnCourses
        public ActionResult Index()
        {
            var pupilsOnCourses = db.PupilsOnCourses.Include(p => p.Course).Include(p => p.Pupils);
            return View(pupilsOnCourses.ToList());
        }

        [Authorize]
        // GET: PupilsOnCourses/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PupilsOnCourse pupilsOnCourse = db.PupilsOnCourses.Find(id);
            if (pupilsOnCourse == null)
            {
                return HttpNotFound();
            }
            return View(pupilsOnCourse);
        }

        [Authorize]
        // GET: PupilsOnCourses/Create
        public ActionResult Create()
        {
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "Name");
            ViewBag.Pupils_id = new SelectList(db.Pupils, "Id", "Author_first_name");
            return View();
        }

        [Authorize]
        // POST: PupilsOnCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pupils_id,Course_id,Date_from,Date_to")] PupilsOnCourse pupilsOnCourse)
        {
            if (ModelState.IsValid)
            {
                db.PupilsOnCourses.Add(pupilsOnCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_id = new SelectList(db.Courses, "Id", "Name", pupilsOnCourse.Course_id);
            ViewBag.Pupils_id = new SelectList(db.Pupils, "Id", "Author_first_name", pupilsOnCourse.Pupils_id);
            return View(pupilsOnCourse);
        }

        [Authorize]
        // GET: PupilsOnCourses/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PupilsOnCourse pupilsOnCourse = db.PupilsOnCourses.Find(id);
            if (pupilsOnCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "Name", pupilsOnCourse.Course_id);
            ViewBag.Pupils_id = new SelectList(db.Pupils, "Id", "Author_first_name", pupilsOnCourse.Pupils_id);
            return View(pupilsOnCourse);
        }

        [Authorize]
        // POST: PupilsOnCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pupils_id,Course_id,Date_from,Date_to")] PupilsOnCourse pupilsOnCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pupilsOnCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "Name", pupilsOnCourse.Course_id);
            ViewBag.Pupils_id = new SelectList(db.Pupils, "Id", "Author_first_name", pupilsOnCourse.Pupils_id);
            return View(pupilsOnCourse);
        }

        [Authorize]
        // GET: PupilsOnCourses/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PupilsOnCourse pupilsOnCourse = db.PupilsOnCourses.Find(id);
            if (pupilsOnCourse == null)
            {
                return HttpNotFound();
            }
            return View(pupilsOnCourse);
        }

        [Authorize]
        // POST: PupilsOnCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PupilsOnCourse pupilsOnCourse = db.PupilsOnCourses.Find(id);
            db.PupilsOnCourses.Remove(pupilsOnCourse);
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
