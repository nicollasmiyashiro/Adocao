using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Adocao.DAL;
using Adocao.Models;

namespace Adocao.Controllers
{
    public class ONGController : Controller
    {
        private AdocaoContext db = new AdocaoContext();

        public ActionResult Index()
        {
            return View(db.ONGs.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,CPF")] ONG oNG)
        {
            if (ModelState.IsValid)
            {
                db.ONGs.Add(oNG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oNG);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ONG oNG = db.ONGs.Find(id);
            if (oNG == null)
            {
                return HttpNotFound();
            }
            return View(oNG);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,CPF")] ONG oNG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oNG);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ONG oNG = db.ONGs.Find(id);
            db.ONGs.Remove(oNG);
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
