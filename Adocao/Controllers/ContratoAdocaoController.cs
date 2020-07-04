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
    public class ContratoAdocaoController : Controller
    {
        private AdocaoContext db = new AdocaoContext();

        public ActionResult Index()
        {
            var contratosAdocao = db.ContratosAdocao.Include(c => c.ONG);
            return View(contratosAdocao.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.ONGID = new SelectList(db.ONGs, "ID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NomePet,NomeAdotante,ONGID")] ContratoAdocao contratoAdocao)
        {
            if (ModelState.IsValid)
            {
                db.ContratosAdocao.Add(contratoAdocao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ONGID = new SelectList(db.ONGs, "ID", "Nome", contratoAdocao.ONGID);
            return View(contratoAdocao);
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
