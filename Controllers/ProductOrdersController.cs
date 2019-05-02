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
    public class ProductOrdersController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: ProductOrders
        public ActionResult Index()
        {
            var productOrders = db.ProductOrders.Include(p => p.OrderDetail).Include(p => p.UserAccout);
            return View(productOrders.ToList());
        }

        // GET: ProductOrders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrder productOrder = db.ProductOrders.Find(id);
            if (productOrder == null)
            {
                return HttpNotFound();
            }
            return View(productOrder);
        }

        // GET: ProductOrders/Create
        public ActionResult Create()
        {
            ViewBag.Order_Id = new SelectList(db.OrderDetails, "Order_Id", "Pro_Id");
            ViewBag.User_Id = new SelectList(db.UserAccouts, "User_Id_", "User_Name");
            return View();
        }

        // POST: ProductOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_Id,User_Id,Order_Date,Order_Price,Order_Picture,Order_Status,Order_Parcel")] ProductOrder productOrder)
        {
            if (ModelState.IsValid)
            {
                db.ProductOrders.Add(productOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_Id = new SelectList(db.OrderDetails, "Order_Id", "Pro_Id", productOrder.Order_Id);
            ViewBag.User_Id = new SelectList(db.UserAccouts, "User_Id_", "User_Name", productOrder.User_Id);
            return View(productOrder);
        }

        // GET: ProductOrders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrder productOrder = db.ProductOrders.Find(id);
            if (productOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_Id = new SelectList(db.OrderDetails, "Order_Id", "Pro_Id", productOrder.Order_Id);
            ViewBag.User_Id = new SelectList(db.UserAccouts, "User_Id_", "User_Name", productOrder.User_Id);
            return View(productOrder);
        }

        // POST: ProductOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_Id,User_Id,Order_Date,Order_Price,Order_Picture,Order_Status,Order_Parcel")] ProductOrder productOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_Id = new SelectList(db.OrderDetails, "Order_Id", "Pro_Id", productOrder.Order_Id);
            ViewBag.User_Id = new SelectList(db.UserAccouts, "User_Id_", "User_Name", productOrder.User_Id);
            return View(productOrder);
        }

        // GET: ProductOrders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrder productOrder = db.ProductOrders.Find(id);
            if (productOrder == null)
            {
                return HttpNotFound();
            }
            return View(productOrder);
        }

        // POST: ProductOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProductOrder productOrder = db.ProductOrders.Find(id);
            db.ProductOrders.Remove(productOrder);
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
