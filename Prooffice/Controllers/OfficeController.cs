using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prooffice.Models;

namespace Prooffice.Controllers
{
    public class OfficeController : Controller
    {
        private dbofficeEntities db = new dbofficeEntities();

        // GET: Office
        public ActionResult Index()
        {
            return View(db.tbloffices.ToList());
        }

        // GET: Office/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbloffice tbloffice = db.tbloffices.Find(id);
            if (tbloffice == null)
            {
                return HttpNotFound();
            }
            return View(tbloffice);
        }

        // GET: Office/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Office/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,employeename,address,phone,email")] tbloffice tbloffice)
        {
            if (ModelState.IsValid)
            {
                db.tbloffices.Add(tbloffice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbloffice);
        }

        // GET: Office/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbloffice tbloffice = db.tbloffices.Find(id);
            if (tbloffice == null)
            {
                return HttpNotFound();
            }
            return View(tbloffice);
        }

        // POST: Office/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,employeename,address,phone,email")] tbloffice tbloffice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbloffice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbloffice);
        }

        // GET: Office/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbloffice tbloffice = db.tbloffices.Find(id);
            if (tbloffice == null)
            {
                return HttpNotFound();
            }
            return View(tbloffice);
        }

        // POST: Office/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbloffice tbloffice = db.tbloffices.Find(id);
            db.tbloffices.Remove(tbloffice);
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
