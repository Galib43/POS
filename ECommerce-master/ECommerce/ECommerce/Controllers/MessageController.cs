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
    public class MessageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Message/
        public ActionResult Index()
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "Message";
                return RedirectToAction("Login", "Users");
            }
            var messages = db.Messages.Include(m => m.Product).Include(m => m.Users);
            return View(messages.ToList());
        }

        // GET: /Message/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: /Message/Create
        public ActionResult Create()
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "Message";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name");
            return View();
        }

        // POST: /Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ProductId,UserId,DateTime,Ip,message1")] Message message)
        {
            message.Ip = Request.UserHostAddress;
            message.DateTime=DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", message.ProductId);
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", message.UserId);
            return View(message);
        }

        // GET: /Message/Edit/5
        public ActionResult Edit(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "Message";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", message.ProductId);
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", message.UserId);
            return View(message);
        }

        // POST: /Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ProductId,UserId,DateTime,Ip,message1")] Message message)
        {
            message.Ip = Request.UserHostAddress;
            message.DateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", message.ProductId);
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", message.UserId);
            return View(message);
        }

        // GET: /Message/Delete/5
        public ActionResult Delete(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "Message";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: /Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
