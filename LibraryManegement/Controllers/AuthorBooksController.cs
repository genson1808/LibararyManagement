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
    public class AuthorBooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: AuthorBooks
        public ActionResult Index()
        {
            var authorBooks = db.AuthorBooks.Include(a => a.Author).Include(a => a.Book);
            return View(authorBooks.ToList());
        }

        [Authorize]
        // GET: AuthorBooks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = db.AuthorBooks.Find(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            return View(authorBook);
        }

        [Authorize]
        // GET: AuthorBooks/Create
        public ActionResult Create()
        {
            ViewBag.Author_id = new SelectList(db.Authors, "Id", "Author_first_name");
            ViewBag.Book_id = new SelectList(db.Books, "IsBn", "Book_title");
            return View();
        }

        [Authorize]
        // POST: AuthorBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Book_id,Author_id")] AuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                db.AuthorBooks.Add(authorBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Author_id = new SelectList(db.Authors, "Id", "Author_first_name", authorBook.Author_id);
            ViewBag.Book_id = new SelectList(db.Books, "IsBn", "Book_title", authorBook.Book_id);
            return View(authorBook);
        }

        [Authorize]
        // GET: AuthorBooks/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = db.AuthorBooks.Find(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.Author_id = new SelectList(db.Authors, "Id", "Author_first_name", authorBook.Author_id);
            ViewBag.Book_id = new SelectList(db.Books, "IsBn", "Book_title", authorBook.Book_id);
            return View(authorBook);
        }

        [Authorize]
        // POST: AuthorBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Book_id,Author_id")] AuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Author_id = new SelectList(db.Authors, "Id", "Author_first_name", authorBook.Author_id);
            ViewBag.Book_id = new SelectList(db.Books, "IsBn", "Book_title", authorBook.Book_id);
            return View(authorBook);
        }

        [Authorize]
        // GET: AuthorBooks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = db.AuthorBooks.Find(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            return View(authorBook);
        }

        [Authorize]
        // POST: AuthorBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AuthorBook authorBook = db.AuthorBooks.Find(id);
            db.AuthorBooks.Remove(authorBook);
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
