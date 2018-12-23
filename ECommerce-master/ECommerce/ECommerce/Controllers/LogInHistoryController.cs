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
    public class LogInHistoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /LogInHistory/
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "LogInHistory";
                return RedirectToAction("Login", "Users");
            }
            var loginhistories = db.LogInHistories.Include(l => l.Users);
            return View(loginhistories.ToList());
        }

        // GET: /LogInHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogInHistory loginhistory = db.LogInHistories.Find(id);
            if (loginhistory == null)
            {
                return HttpNotFound();
            }
            return View(loginhistory);
        }

        // GET: /LogInHistory/Create
        public ActionResult Create()
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "LogInHistory";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name");
            return View();
        }

        // POST: /LogInHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LogInHistory loginhistory)
        {
            loginhistory.DateTime=DateTime.Now;
            loginhistory.Ip = Request.UserHostAddress;
            if (ModelState.IsValid)
            {
                db.LogInHistories.Add(loginhistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", loginhistory.UserId);
            return View(loginhistory);
        }

        // GET: /LogInHistory/Edit/5
        public ActionResult Edit(int? id)
        {


            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "LogInHistory";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogInHistory loginhistory = db.LogInHistories.Find(id);
            if (loginhistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", loginhistory.UserId);
            return View(loginhistory);
        }

        // POST: /LogInHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,UserId,DateTime,Ip")] LogInHistory loginhistory)
        {
            loginhistory.DateTime = DateTime.Now;
            loginhistory.Ip = Request.UserHostAddress;
            if (ModelState.IsValid)
            {
                db.Entry(loginhistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", loginhistory.UserId);
            return View(loginhistory);
        }

        // GET: /LogInHistory/Delete/5
        public ActionResult Delete(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "LogInHistory";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogInHistory loginhistory = db.LogInHistories.Find(id);
            if (loginhistory == null)
            {
                return HttpNotFound();
            }
            return View(loginhistory);
        }

        // POST: /LogInHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogInHistory loginhistory = db.LogInHistories.Find(id);
            db.LogInHistories.Remove(loginhistory);
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
