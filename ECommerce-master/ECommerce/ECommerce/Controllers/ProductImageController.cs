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
    public class ProductImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ProductImage/
        public ActionResult Index()
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "ProductImage";
                return RedirectToAction("Login", "Users");
            }
            var productimages = db.ProductImages.Include(p => p.Product);
            return View(productimages.ToList());
        }

        // GET: /ProductImage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productimage = db.ProductImages.Find(id);
            if (productimage == null)
            {
                return HttpNotFound();
            }
            return View(productimage);
        }

        // GET: /ProductImage/Create
        public ActionResult Create()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "ProductImage";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: /ProductImage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductId,Image,Title")] ProductImage productimage,HttpPostedFileBase Image)
        {
            productimage.Image = System.IO.Path.GetFileName(Image.FileName);

            if (ModelState.IsValid)
            {
                db.ProductImages.Add(productimage);
                db.SaveChanges();
                Image.SaveAs(Server.MapPath("../Uploads/UsersImages/" + productimage.Id.ToString() + "_" + productimage.Image));
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productimage.ProductId);
            return View(productimage);
        }

        // GET: /ProductImage/Edit/5
        public ActionResult Edit(int? id )
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "ProductImage";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productimage = db.ProductImages.Find(id);
            if (productimage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productimage.ProductId);
            return View(productimage);
        }

        // POST: /ProductImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductId,Image,Title")] ProductImage productimage,HttpPostedFileBase Image)
        {
            productimage.Image = System.IO.Path.GetFileName(Image.FileName);
            if (ModelState.IsValid)
            {
                db.Entry(productimage).State = EntityState.Modified;
                db.SaveChanges();
                Image.SaveAs(Server.MapPath("../Uploads/UsersImages/" + productimage.Id.ToString() + "_" + productimage.Image));
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productimage.ProductId);
            return View(productimage);
        }

        // GET: /ProductImage/Delete/5
        public ActionResult Delete(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "ProductImage";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productimage = db.ProductImages.Find(id);
            if (productimage == null)
            {
                return HttpNotFound();
            }
            return View(productimage);
        }

        // POST: /ProductImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductImage productimage = db.ProductImages.Find(id);
            db.ProductImages.Remove(productimage);
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
