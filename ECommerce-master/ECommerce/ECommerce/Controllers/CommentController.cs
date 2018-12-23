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
    public class CommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Comment/
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "Comment";
                return RedirectToAction("Login", "Users");
            }
            var comments = db.Comments.Include(c => c.Product).Include(c => c.Users);
            return View(comments.ToList());
        }

        // GET: /Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: /Comment/Create
        public ActionResult Create()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "Comment";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.Comments.Count <= 0), "Id", "Name");
            
            return View();
        }

        // POST: /Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,UserId,DateTime,Ip,Comment1")] Comment comment)
        {
            comment.Ip = Request.UserHostAddress;
            comment.DateTime=DateTime.Now;
            comment.UserId = (int) Session["id"];
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.Comments.Count <= 0), "Id", "Name", comment.ProductId);
           
            return View(comment);
        }

        // GET: /Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "Comment";
                return RedirectToAction("Login", "Users");
            }
 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products.Where(p=>p.Comments.Count <=0), "Id", "Name", comment.ProductId);
          
            return View(comment);
        }

        // POST: /Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,UserId,DateTime,Ip,Comment1")] Comment comment)
        {
            comment.Ip = Request.UserHostAddress;
            comment.DateTime = DateTime.Now;
            comment.UserId = (int)Session["id"];
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.Comments.Count <= 0), "Id", "Name", comment.ProductId);
           
            return View(comment);
        }

        // GET: /Comment/Delete/5
        public ActionResult Delete(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "Comment";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
