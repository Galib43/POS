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
    public class ProductRattingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ProductRatting/
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "ProductRating";
                return RedirectToAction("Login", "Users");
            }
            var productratings = db.ProductRatings.Include(p => p.Product).Include(p => p.Users);
            return View(productratings.ToList());
        }

        // GET: /ProductRatting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRating productrating = db.ProductRatings.Find(id);
            if (productrating == null)
            {
                return HttpNotFound();
            }
            return View(productrating);
        }

        // GET: /ProductRatting/Create
        public ActionResult Create()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "ProductRating";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.ProductRatings.Count <= 0), "Id", "Name");
           
            return View();
        }

        // POST: /ProductRatting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductId,UserId,DateTime,Ip")] ProductRating productrating)
        {
            productrating.Ip = Request.UserHostAddress;
            productrating.DateTime=DateTime.Now;
            productrating.UserId = (int) Session["id"];
            if (ModelState.IsValid)
            {
                db.ProductRatings.Add(productrating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.ProductRatings.Count <= 0), "Id", "Name", productrating.ProductId);
           
            return View(productrating);
        }

        // GET: /ProductRatting/Edit/5
        public ActionResult Edit(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "ProductRating";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRating productrating = db.ProductRatings.Find(id);
            if (productrating == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.ProductRatings.Count <= 0), "Id", "Name", productrating.ProductId);
         
            return View(productrating);
        }

        // POST: /ProductRatting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductId,UserId,DateTime,Ip")] ProductRating productrating)
        {
            productrating.Ip = Request.UserHostAddress;
            productrating.UserId = (int) Session["id"];
            productrating.DateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(productrating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.ProductRatings.Count <= 0),"Id", "Name", productrating.ProductId);
           
            return View(productrating);
        }

        // GET: /ProductRatting/Delete/5
        public ActionResult Delete(int? id)
        {


            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "ProductRating";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRating productrating = db.ProductRatings.Find(id);
            if (productrating == null)
            {
                return HttpNotFound();
            }
            return View(productrating);
        }

        // POST: /ProductRatting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductRating productrating = db.ProductRatings.Find(id);
            db.ProductRatings.Remove(productrating);
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
