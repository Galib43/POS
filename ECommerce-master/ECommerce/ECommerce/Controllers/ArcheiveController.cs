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
    public class ArcheiveController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Archeive/
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "Archieve";
                return RedirectToAction("Login", "Users");
            }
            var archieves = db.Archieves.Include(a => a.Product).Include(a => a.Users);
            return View(archieves.ToList());
        }

        // GET: /Archeive/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archieve archieve = db.Archieves.Find(id);
            if (archieve == null)
            {
                return HttpNotFound();
            }
            return View(archieve);
        }

        // GET: /Archeive/Create
        public ActionResult Create()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "Archieve";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name");
            return View();
        }

        // POST: /Archeive/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductId,UserId,DateTime,Ip")] Archieve archieve)
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "Archieve";
                return RedirectToAction("Login", "Users");
            }
            if (ModelState.IsValid)
            {
                db.Archieves.Add(archieve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", archieve.ProductId);
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", archieve.UserId);
            return View(archieve);
        }

        // GET: /Archeive/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "Archieve";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archieve archieve = db.Archieves.Find(id);
            if (archieve == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", archieve.ProductId);
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", archieve.UserId);
            return View(archieve);
        }

        // POST: /Archeive/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductId,UserId,DateTime,Ip")] Archieve archieve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(archieve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", archieve.ProductId);
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", archieve.UserId);
            return View(archieve);
        }

        // GET: /Archeive/Delete/5
        public ActionResult Delete(int? id)
        {


            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "Archieve";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archieve archieve = db.Archieves.Find(id);
            if (archieve == null)
            {
                return HttpNotFound();
            }
            return View(archieve);
        }

        // POST: /Archeive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Archieve archieve = db.Archieves.Find(id);
            db.Archieves.Remove(archieve);
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
