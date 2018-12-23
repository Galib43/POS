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
    public class ProdcutCloseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ProdcutClose/
        public ActionResult Index()
        {


            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "ProductClose";
                return RedirectToAction("Login", "Users");
            }
            var productcloses = db.ProductCloses.Include(p => p.CloseType).Include(p => p.Product);
            return View(productcloses.ToList());
        }

        // GET: /ProdcutClose/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductClose productclose = db.ProductCloses.Find(id);
            if (productclose == null)
            {
                return HttpNotFound();
            }
            return View(productclose);
        }

        // GET: /ProdcutClose/Create
        public ActionResult Create()
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "ProductClose";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.ClosingTypeId = new SelectList(db.CloseTypes, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: /ProdcutClose/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductId,DateTime,ClosingTypeId")] ProductClose productclose)
        {
            if (ModelState.IsValid)
            {
                db.ProductCloses.Add(productclose);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClosingTypeId = new SelectList(db.CloseTypes, "Id", "Name", productclose.ClosingTypeId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productclose.ProductId);
            return View(productclose);
        }

        // GET: /ProdcutClose/Edit/5
        public ActionResult Edit(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "ProductClose";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductClose productclose = db.ProductCloses.Find(id);
            if (productclose == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClosingTypeId = new SelectList(db.CloseTypes, "Id", "Name", productclose.ClosingTypeId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productclose.ProductId);
            return View(productclose);
        }

        // POST: /ProdcutClose/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductId,DateTime,ClosingTypeId")] ProductClose productclose)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productclose).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClosingTypeId = new SelectList(db.CloseTypes, "Id", "Name", productclose.ClosingTypeId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productclose.ProductId);
            return View(productclose);
        }

        // GET: /ProdcutClose/Delete/5
        public ActionResult Delete(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "ProductClose";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductClose productclose = db.ProductCloses.Find(id);
            if (productclose == null)
            {
                return HttpNotFound();
            }
            return View(productclose);
        }

        // POST: /ProdcutClose/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductClose productclose = db.ProductCloses.Find(id);
            db.ProductCloses.Remove(productclose);
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
