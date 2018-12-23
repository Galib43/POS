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
    public class ProdcutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Prodcut/
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "Product";
                return RedirectToAction("Login","Users");
            }



            var products = db.Products.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Condition).Include(p => p.Users);
            return View(products.ToList());
        }

        // GET: /Prodcut/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Prodcut/Create
        public ActionResult Create()
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "Product";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.ConditionId = new SelectList(db.Conditions, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name");
            return View();
        }

        // POST: /Prodcut/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            product.UserId = (int) Session["id"];
            product.Ip = Request.UserHostAddress;
            product.CreateDate=DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ConditionId = new SelectList(db.Conditions, "Id", "Name", product.ConditionId);
         
            return View(product);
        }

        // GET: /Prodcut/Edit/5
        public ActionResult Edit(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "Product";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ConditionId = new SelectList(db.Conditions, "Id", "Name", product.ConditionId);
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", product.UserId);
            return View(product);
        }

        // POST: /Prodcut/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Description,CategoryId,BrandId,ConditionId,UserId,RegularPrice,OfferPrice,Negotiable,Links,Video,CreateDate,Ip")] Product product)
        {
            product.UserId = (int)Session["id"];
            product.Ip = Request.UserHostAddress;
            product.CreateDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ConditionId = new SelectList(db.Conditions, "Id", "Name", product.ConditionId);
           
            return View(product);
        }

        // GET: /Prodcut/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Prodcut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
