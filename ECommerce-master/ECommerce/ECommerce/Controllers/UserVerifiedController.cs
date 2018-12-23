using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class UserVerifiedController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /UserVerified/
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "UserVerified";
                return RedirectToAction("Login", "Users");
            }
            var userverifieds = db.UserVerifieds.Include(u => u.Users);
            return View(userverifieds.ToList());
        }

        // GET: /UserVerified/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserVerified userverified = db.UserVerifieds.Find(id);
            if (userverified == null)
            {
                return HttpNotFound();
            }
            return View(userverified);
        }

        // GET: /UserVerified/Create
        public ActionResult Create()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "UserVerified";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name");
            return View();
        }

        // POST: /UserVerified/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserId,DateTime,Ip")] UserVerified userverified)
        {
            if (ModelState.IsValid)
            {
                db.UserVerifieds.Add(userverified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", userverified.UserId);
            return View(userverified);
        }

        // GET: /UserVerified/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "UserVerified";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserVerified userverified = db.UserVerifieds.Find(id);
            if (userverified == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", userverified.UserId);
            return View(userverified);
        }

        // POST: /UserVerified/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserId,DateTime,Ip")] UserVerified userverified)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userverified).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", userverified.UserId);
            return View(userverified);
        }

        // GET: /UserVerified/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "UserVerified";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserVerified userverified = db.UserVerifieds.Find(id);
            if (userverified == null)
            {
                return HttpNotFound();
            }
            return View(userverified);
        }

        // POST: /UserVerified/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserVerified userverified = db.UserVerifieds.Find(id);
            db.UserVerifieds.Remove(userverified);
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
