using ProiectCEBD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProiectCEBD.Controllers
{
    public class Admin_Tipuri_Unitati_CazareController : Controller
    {
        private ProiectEntities db = new ProiectEntities();

        public ActionResult Index()
        {
            ViewBag.IsLoginPage = true;
            return View(db.TIPURI_UNITATI_DE_CAZARE.ToList());
        }

        public ActionResult CreareTipUnitate()
        {
            ViewBag.IsLoginPage = true;
            var ultimulId = db.TIPURI_UNITATI_DE_CAZARE.Max(t => (decimal?)t.IDTIPURIUNITATICAZARE) ?? 0;
            var urmatorulId = Convert.ToInt32(ultimulId) + 1;

            var model = new TIPURI_UNITATI_DE_CAZARE
            {
                IDTIPURIUNITATICAZARE = Convert.ToInt32(urmatorulId)
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreareTipUnitate([Bind(Include = "IDTIPURIUNITATICAZARE, DENUMIRE, DESCRIERE")] TIPURI_UNITATI_DE_CAZARE tipUnitateCazare)
        {
            ViewBag.IsLoginPage = true;
            if (ModelState.IsValid)
            {
                db.TIPURI_UNITATI_DE_CAZARE.Add(tipUnitateCazare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipUnitateCazare);
        }

        public ActionResult EditareTipUnitate(string tipunitate, decimal id)
        {
            ViewBag.IsLoginPage = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPURI_UNITATI_DE_CAZARE tipUnitateCazare = db.TIPURI_UNITATI_DE_CAZARE.Find(id);
            if (tipUnitateCazare == null)
            {
                return HttpNotFound();
            }

            ViewBag.IDTipUnitateCazare = tipUnitateCazare.IDTIPURIUNITATICAZARE;

            return View(tipUnitateCazare);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditareTipUnitate([Bind(Include = "IDTIPURIUNITATICAZARE, DENUMIRE, DESCRIERE")] TIPURI_UNITATI_DE_CAZARE tipUnitateCazare)
        {
            ViewBag.IsLoginPage = true;
            if (ModelState.IsValid)
            {
                db.Entry(tipUnitateCazare).State = EntityState.Modified;
                db.SaveChanges();
                return View(tipUnitateCazare);
            }
            return View(tipUnitateCazare);
        }

        public ActionResult StergereTipUnitate(decimal id)
        {
            ViewBag.IsLoginPage = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPURI_UNITATI_DE_CAZARE tipUnitateCazare = db.TIPURI_UNITATI_DE_CAZARE.Find(id);
            if (tipUnitateCazare == null)
            {
                return HttpNotFound();
            }

            return View(tipUnitateCazare);
        }

        [HttpPost, ActionName("StergereTipUnitate")]
        [ValidateAntiForgeryToken]
        public ActionResult StergereTipUnitateConfirmare(decimal id)
        {
            ViewBag.IsLoginPage = true;
            TIPURI_UNITATI_DE_CAZARE tipUnitateCazare = db.TIPURI_UNITATI_DE_CAZARE.Find(id);
            if (tipUnitateCazare == null)
            {
                return HttpNotFound();
            }

            db.TIPURI_UNITATI_DE_CAZARE.Remove(tipUnitateCazare);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}