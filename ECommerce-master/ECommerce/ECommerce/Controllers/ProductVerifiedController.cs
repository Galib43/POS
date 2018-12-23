using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class ProductVerifiedController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ProductVerified/
        public ActionResult Index()
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "ProductVerified";
                return RedirectToAction("Login", "Users");
            }
            var productverifieds = db.ProductVerifieds.Include(p => p.AdminUser).Include(p => p.Product);
            return View(productverifieds.ToList());
        }

        // GET: /ProductVerified/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVerified productverified = db.ProductVerifieds.Find(id);
            if (productverified == null)
            {
                return HttpNotFound();
            }
            return View(productverified);
        }

        // GET: /ProductVerified/Create
        public ActionResult Create()
        {


            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "ProductVerified";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.ProductVerifieds.Count <= 0), "Id", "Name");
           
            return View();
        }

        // POST: /ProductVerified/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductId,AdminUserId,DateTime,Ip")] ProductVerified productverified)
        {
            productverified.Ip = Request.UserHostAddress;
            productverified.DateTime = DateTime.Now;
            productverified.AdminUserId = (int)Session["id"]; 
            if (ModelState.IsValid)
            {
                db.ProductVerifieds.Add(productverified);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    
                    Console.WriteLine(ex);
                }
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products.Where(p=>p.ProductVerifieds.Count<=0), "Id", "Name");
           
            return View(productverified);
        }

        // GET: /ProductVerified/Edit/5
        public ActionResult Edit(int? id)
        {


            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "ProductVerified";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVerified productverified = db.ProductVerifieds.Find(id);
            if (productverified == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.ProductVerifieds.Count <= 0), "Id", "Name");
          
            return View(productverified);
        }

        // POST: /ProductVerified/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductId,AdminUserId,DateTime,Ip")] ProductVerified productverified)
        {
            productverified.Ip = Request.UserHostAddress;
            productverified.DateTime = DateTime.Now;
            productverified.AdminUserId = (int)Session["id"]; 
            if (ModelState.IsValid)
            {
                db.Entry(productverified).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.ProductVerifieds.Count <= 0), "Id", "Name");
          
            return View(productverified);
        }

        // GET: /ProductVerified/Delete/5
        public ActionResult Delete(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "ProductVerified";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVerified productverified = db.ProductVerifieds.Find(id);
            if (productverified == null)
            {
                return HttpNotFound();
            }
            return View(productverified);
        }

        // POST: /ProductVerified/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductVerified productverified = db.ProductVerifieds.Find(id);
            db.ProductVerifieds.Remove(productverified);
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
