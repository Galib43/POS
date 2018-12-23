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
    public class AdminUserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Admin/
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "AdminUser";
                return RedirectToAction("Login","Users");
            }
            var adminusers = db.AdminUsers.Include(a => a.Users);
            return View(adminusers.ToList());
        }

        // GET: /Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUser adminuser = db.AdminUsers.Find(id);
            if (adminuser == null)
            {
                return HttpNotFound();
            }
            return View(adminuser);
        }

        // GET: /Admin/Create
        public ActionResult Create()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "AdminUser";
                return RedirectToAction("Login", "Users");
            }
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name");
            return View();
        }

        // POST: /Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserId")] AdminUser adminuser)
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "AdminUser";
                return RedirectToAction("Login", "Users");
            }
            if (ModelState.IsValid)
            {
                db.AdminUsers.Add(adminuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", adminuser.UserId);
            return View(adminuser);
        }

        // GET: /Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "AdminUser";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUser adminuser = db.AdminUsers.Find(id);
            if (adminuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", adminuser.UserId);
            return View(adminuser);
        }

        // POST: /Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserId")] AdminUser adminuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Userses, "Id", "Name", adminuser.UserId);
            return View(adminuser);
        }

        // GET: /Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "AdminUser";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminUser adminuser = db.AdminUsers.Find(id);
            if (adminuser == null)
            {
                return HttpNotFound();
            }
            return View(adminuser);
        }

        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminUser adminuser = db.AdminUsers.Find(id);
            db.AdminUsers.Remove(adminuser);
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
