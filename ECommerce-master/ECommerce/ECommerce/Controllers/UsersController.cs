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
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Users/
        public ActionResult Index()
        {
            //if (Session["type"] == null || Session["type"] == "")
            //{
            //    Session["dv"] = "Index";
            //    Session["dc"] = "Users";
            //    return RedirectToAction("Login");
            //}

            var userses = db.Userses.Include(u => u.City);
            return View(userses.ToList());
        }

        // GET: /Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Userses.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var usr = db.Userses.Where(u => u.Email.ToLower() == loginModel.Email.ToLower() && u.Password == loginModel.Password).First();
                    if (usr == null)
                    {
                        ViewBag.Error = "Invalid Email Or Password";
                    }
                    else if (usr.AdminUser == null)
                    {
                        ViewBag.Error = "You Are Not Administrator";
                    }

                    else
                    {
                        Session["Id"] = usr.Id;
                        Session["Name"] = usr.Name;
                        Session["type"] = "Admin";

                        if (Session["dv"] == null || Session["dv"].ToString() == "")
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        return RedirectToAction(Session["dv"].ToString(), Session["dc"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine();
                }
              
               
            }
            return View(loginModel);
        }

        public ActionResult MyAccount()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["Id"] = "";
            Session["Name"] = "";
            Session["type"] = "";
            return View();
        }



        // GET: /Users/Create
        public ActionResult Create()
        {
            //if (Session["type"] == null || Session["type"] == "")
            //{
            //    Session["dv"] = "Create";
            //    Session["dc"] = "Users";
            //    return RedirectToAction("Login");
            //}

            ViewBag.CityId = new SelectList(db.Cities, "Id", "NAME");
            return View();
        }

        // POST: /Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Contact,Email,Password,ConfirmPassword,Gender,JoinDate,Ip,DateOfBirth,Address,CityId")] Users users)
        {
            users.Ip = Request.UserHostAddress;
            users.JoinDate=DateTime.Now;

            //if (Session["type"] == null || Session["type"] == "")
            //{
            //    Session["dv"] = "Create";
            //    Session["dc"] = "Users";
            //    return RedirectToAction("Login");
            //}



            if (ModelState.IsValid)
            {
                db.Userses.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "NAME", users.CityId);
            return View(users);
        }

        // GET: /Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Edit";
                Session["dc"] = "Users";
                return RedirectToAction("Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Userses.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "NAME", users.CityId);
            return View(users);
        }

        // POST: /Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Contact,Email,Password,ConfirmPassword,Gender,JoinDate,Ip,DateOfBirth,Address,CityId")] Users users)
        {
            users.Ip = Request.UserHostAddress;
            users.JoinDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "NAME", users.CityId);
            return View(users);
        }

        // GET: /Users/Delete/5
        public ActionResult Delete(int? id)
        {

            if (Session["type"] == null || Session["type"] == "")
            {
                Session["dv"] = "Delete";
                Session["dc"] = "Users";
                return RedirectToAction("Login");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Userses.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Userses.Find(id);
            db.Userses.Remove(users);
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
