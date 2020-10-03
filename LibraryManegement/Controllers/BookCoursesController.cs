using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManegement.Models;

namespace LibraryManegement.Controllers
{
    public class BookCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: BookCourses
        public ActionResult Index()
        {
            var bookCourses = db.BookCourses.Include(b => b.Book).Include(b => b.Course);
            return View(bookCourses.ToList());
        }

        [Authorize]
        // GET: BookCourses/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCourse bookCourse = db.BookCourses.Find(id);
            if (bookCourse == null)
            {
                return HttpNotFound();
            }
            return View(bookCourse);
        }

        [Authorize]
        // GET: BookCourses/Create
        public ActionResult Create()
        {
            ViewBag.Book_id = new SelectList(db.Books, "IsBn", "Book_title");
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "Name");
            return View();
        }

        [Authorize]
        // POST: BookCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Book_id,Course_id")] BookCourse bookCourse)
        {
            if (ModelState.IsValid)
            {
                db.BookCourses.Add(bookCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_id = new SelectList(db.Books, "IsBn", "Book_title", bookCourse.Book_id);
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "Name", bookCourse.Course_id);
            return View(bookCourse);
        }

        [Authorize]
        // GET: BookCourses/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCourse bookCourse = db.BookCourses.Find(id);
            if (bookCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_id = new SelectList(db.Books, "IsBn", "Book_title", bookCourse.Book_id);
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "Name", bookCourse.Course_id);
            return View(bookCourse);
        }

        [Authorize]
        // POST: BookCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Book_id,Course_id")] BookCourse bookCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_id = new SelectList(db.Books, "IsBn", "Book_title", bookCourse.Book_id);
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "Name", bookCourse.Course_id);
            return View(bookCourse);
        }

        [Authorize]
        // GET: BookCourses/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCourse bookCourse = db.BookCourses.Find(id);
            if (bookCourse == null)
            {
                return HttpNotFound();
            }
            return View(bookCourse);
        }

        [Authorize]
        // POST: BookCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            BookCourse bookCourse = db.BookCourses.Find(id);
            db.BookCourses.Remove(bookCourse);
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
