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
    public class ProductLikeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ProductLike/
        public ActionResult Index()
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "ProductLike";
                return RedirectToAction("Login", "Users");
            }
            var productlikes = db.ProductLikes.Include(p => p.Product).Include(p => p.Users);
            return View(productlikes.ToList());
        }

        // GET: /ProductLike/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductLike productlike = db.ProductLikes.Find(id);
            if (productlike == null)
            {
                return HttpNotFound();
            }
            return View(productlike);
        }

        // GET: /ProductLike/Create
        public ActionResult Create()
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "ProductLike";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.ProductId = new SelectList(db.Products.Where(p=>p.ProductLikes.Count<=0),"Id", "Name");
           
            return View();
        }

        // POST: /ProductLike/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductId,UserId,DateTime,Ip")] ProductLike productlike)
        {
            productlike.Ip = Request.UserHostAddress;
            productlike.DateTime=DateTime.Now;
            productlike.UserId = (int) Session["id"];

            if (ModelState.IsValid)
            {
                db.ProductLikes.Add(productlike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.ProductLikes.Count <= 0), "Id", "Name", productlike.ProductId);
           
            return View(productlike);
        }

        // GET: /ProductLike/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "ProductLike";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductLike productlike = db.ProductLikes.Find(id);
            if (productlike == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.ProductLikes.Count <= 0), "Id", "Name", productlike.ProductId);
           
            return View(productlike);
        }

        // POST: /ProductLike/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductId,UserId,DateTime,Ip")] ProductLike productlike)
        {
            productlike.Ip = Request.UserHostAddress;
            productlike.DateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(productlike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.ProductLikes.Count <= 0), "Id", "Name", productlike.ProductId);
          
            return View(productlike);
        }

        // GET: /ProductLike/Delete/5
        public ActionResult Delete(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "ProductLike";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductLike productlike = db.ProductLikes.Find(id);
            if (productlike == null)
            {
                return HttpNotFound();
            }
            return View(productlike);
        }

        // POST: /ProductLike/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductLike productlike = db.ProductLikes.Find(id);
            db.ProductLikes.Remove(productlike);
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
