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
    public class CloseTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /CloseType/
        public ActionResult Index()
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Index";
                Session["dc"] = "CloseType";
                return RedirectToAction("Login", "Users");
            }
            return View(db.CloseTypes.ToList());
        }

        // GET: /CloseType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CloseType closetype = db.CloseTypes.Find(id);
            if (closetype == null)
            {
                return HttpNotFound();
            }
            return View(closetype);
        }

        // GET: /CloseType/Create
        public ActionResult Create()
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Create";
                Session["dc"] = "CloseType";
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        // POST: /CloseType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Decription")] CloseType closetype)
        {
            if (ModelState.IsValid)
            {
                db.CloseTypes.Add(closetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(closetype);
        }

        // GET: /CloseType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "CloseType";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CloseType closetype = db.CloseTypes.Find(id);
            if (closetype == null)
            {
                return HttpNotFound();
            }
            return View(closetype);
        }

        // POST: /CloseType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Decription")] CloseType closetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(closetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(closetype);
        }

        // GET: /CloseType/Delete/5
        public ActionResult Delete(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "CloseType";
                return RedirectToAction("Login", "Users");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CloseType closetype = db.CloseTypes.Find(id);
            if (closetype == null)
            {
                return HttpNotFound();
            }
            return View(closetype);
        }

        // POST: /CloseType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CloseType closetype = db.CloseTypes.Find(id);
            db.CloseTypes.Remove(closetype);
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
