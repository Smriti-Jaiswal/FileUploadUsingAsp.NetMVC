using Prooffice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Net;
using Prooffice;

namespace Prooffice.Controllers
{
    public class tblofficesController : Controller
    {
      dbofficeEntities db = new dbofficeEntities();

        // GET: tbloffices
        public ActionResult Index()
        {
            return View(db.tbloffices.ToList());
        }

        // GET: tbloffices/Details/5
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

        // GET: tbloffices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbloffices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: tbloffices/Edit/5
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

        // POST: tbloffices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: tbloffices/Delete/5
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

        // POST: tbloffices/Delete/5
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

        public ActionResult test()
        {
            return View();
        }
    }
}
