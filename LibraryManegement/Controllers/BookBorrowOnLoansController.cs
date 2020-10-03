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
    public class BookBorrowOnLoansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: BookBorrowOnLoans
        public ActionResult Index()
        {
            var bookBorrowOnLoans = db.BookBorrowOnLoans.Include(b => b.Book).Include(b => b.Pupils);
            return View(bookBorrowOnLoans.ToList());
        }

        [Authorize]
        // GET: BookBorrowOnLoans/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookBorrowOnLoan bookBorrowOnLoan = db.BookBorrowOnLoans.Find(id);
            if (bookBorrowOnLoan == null)
            {
                return HttpNotFound();
            }
            return View(bookBorrowOnLoan);
        }

        [Authorize]
        // GET: BookBorrowOnLoans/Create
        public ActionResult Create()
        {
            ViewBag.Book_id = new SelectList(db.Books, "IsBn", "Book_title");
            ViewBag.Pupils_id = new SelectList(db.Pupils, "Id", "Author_first_name");
            return View();
        }

        [Authorize]
        // POST: BookBorrowOnLoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Book_id,Pupils_id,Fine_paid,Lost,Overdue,Date_issued,Date_due_to_return,Date_returned")] BookBorrowOnLoan bookBorrowOnLoan)
        {
            if (ModelState.IsValid)
            {
                db.BookBorrowOnLoans.Add(bookBorrowOnLoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_id = new SelectList(db.Books, "IsBn", "Book_title", bookBorrowOnLoan.Book_id);
            ViewBag.Pupils_id = new SelectList(db.Pupils, "Id", "Author_first_name", bookBorrowOnLoan.Pupils_id);
            return View(bookBorrowOnLoan);
        }

        [Authorize]
        // GET: BookBorrowOnLoans/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookBorrowOnLoan bookBorrowOnLoan = db.BookBorrowOnLoans.Find(id);
            if (bookBorrowOnLoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_id = new SelectList(db.Books, "IsBn", "Book_title", bookBorrowOnLoan.Book_id);
            ViewBag.Pupils_id = new SelectList(db.Pupils, "Id", "Author_first_name", bookBorrowOnLoan.Pupils_id);
            return View(bookBorrowOnLoan);
        }

        [Authorize]
        // POST: BookBorrowOnLoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Book_id,Pupils_id,Fine_paid,Lost,Overdue,Date_issued,Date_due_to_return,Date_returned")] BookBorrowOnLoan bookBorrowOnLoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookBorrowOnLoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_id = new SelectList(db.Books, "IsBn", "Book_title", bookBorrowOnLoan.Book_id);
            ViewBag.Pupils_id = new SelectList(db.Pupils, "Id", "Author_first_name", bookBorrowOnLoan.Pupils_id);
            return View(bookBorrowOnLoan);
        }

        [Authorize]
        // GET: BookBorrowOnLoans/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookBorrowOnLoan bookBorrowOnLoan = db.BookBorrowOnLoans.Find(id);
            if (bookBorrowOnLoan == null)
            {
                return HttpNotFound();
            }
            return View(bookBorrowOnLoan);
        }

        [Authorize]
        // POST: BookBorrowOnLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            BookBorrowOnLoan bookBorrowOnLoan = db.BookBorrowOnLoans.Find(id);
            db.BookBorrowOnLoans.Remove(bookBorrowOnLoan);
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
