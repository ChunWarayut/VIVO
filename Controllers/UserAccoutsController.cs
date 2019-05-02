using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VIVO.Models;

namespace VIVO.Controllers
{
    public class UserAccoutsController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: UserAccouts
        public ActionResult Index()
        {
            return View(db.UserAccouts.ToList());
        }

        // GET: UserAccouts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccout userAccout = db.UserAccouts.Find(id);
            if (userAccout == null)
            {
                return HttpNotFound();
            }
            return View(userAccout);
        }

        // GET: UserAccouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_Id_,User_Name,User_Lastname,User_Sex,User_Tel,User_Email,User_Address")] UserAccout userAccout)
        {
            if (ModelState.IsValid)
            {
                db.UserAccouts.Add(userAccout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAccout);
        }

        // GET: UserAccouts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccout userAccout = db.UserAccouts.Find(id);
            if (userAccout == null)
            {
                return HttpNotFound();
            }
            return View(userAccout);
        }

        // POST: UserAccouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_Id_,User_Name,User_Lastname,User_Sex,User_Tel,User_Email,User_Address")] UserAccout userAccout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAccout);
        }

        // GET: UserAccouts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccout userAccout = db.UserAccouts.Find(id);
            if (userAccout == null)
            {
                return HttpNotFound();
            }
            return View(userAccout);
        }

        // POST: UserAccouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserAccout userAccout = db.UserAccouts.Find(id);
            db.UserAccouts.Remove(userAccout);
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
