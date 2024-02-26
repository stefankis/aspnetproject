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
    public class Admin_Unitati_CazareController : Controller
    {
        private ProiectEntities db = new ProiectEntities();

        // GET: Admin_Unitati_Cazare
        public ActionResult IndexShow()
        {
            ViewBag.IsLoginPage = true;
            return View(db.UNITATI_DE_CAZARE.ToList());
        }

        public ActionResult Index(decimal? idComplexCazare = null)
        {
            ViewBag.IsLoginPage = true;
            var unitatiCazare = db.UNITATI_DE_CAZARE.AsQueryable();

            if (idComplexCazare.HasValue)
            {
                unitatiCazare = unitatiCazare.Where(u => u.IDCOMPLEXCAZARE == idComplexCazare);
            }

            if (db.COMPLEX_CAZARE.Any())
            {
                ViewBag.IDComplexCazare = new SelectList(db.COMPLEX_CAZARE, "IDCOMPLEXCAZARE", "DENUMIRE");
            }
            else
            {
                ViewBag.IDComplexCazare = Enumerable.Empty<SelectListItem>();
            }

            return View(unitatiCazare.ToList());
        }

        public ActionResult CreareUnitate()
        {
            if (db.COMPLEX_CAZARE.Any())
            {
                ViewBag.ComplexCazareList = new SelectList(db.COMPLEX_CAZARE, "IDCOMPLEXCAZARE", "DENUMIRE");
            }
            else
            {
                ViewBag.ComplexCazareList = Enumerable.Empty<SelectListItem>();
            }

            if (db.TIPURI_UNITATI_DE_CAZARE.Any())
            {
                ViewBag.TipuriUnitatiCazareList = new SelectList(db.TIPURI_UNITATI_DE_CAZARE, "IDTIPURIUNITATICAZARE", "DENUMIRE");
            }
            else
            {
                ViewBag.TipuriUnitatiCazareList = Enumerable.Empty<SelectListItem>();
            }

            ViewBag.IsLoginPage = true;
            var ultimulId = db.UNITATI_DE_CAZARE.Max(t => (decimal?)t.IDUNITATICAZARE) ?? 0;
            var urmatorulId = Convert.ToInt32(ultimulId) + 1;

            var model = new UNITATI_DE_CAZARE
            {
                IDUNITATICAZARE = Convert.ToInt32(urmatorulId)
            };


            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreareUnitate([Bind(Include = "IDUNITATICAZARE,IDCOMPLEXCAZARE,IDTIPURIUNITATICAZARE,NUME,PRET")] UNITATI_DE_CAZARE unitateCazare)
        {
            ViewBag.IsLoginPage = true;
            if (ModelState.IsValid)
            {
                db.UNITATI_DE_CAZARE.Add(unitateCazare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unitateCazare);
        }

        public ActionResult EditareUnitate(string unitate, decimal id)
        {
            ViewBag.IsLoginPage = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UNITATI_DE_CAZARE unitateCazare = db.UNITATI_DE_CAZARE.Find(id);
            if (unitateCazare == null)
            {
                return HttpNotFound();
            }

            ViewBag.IDComplex = unitateCazare.IDCOMPLEXCAZARE;

            return View(unitateCazare);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditareUnitate([Bind(Include = "IDUNITATICAZARE,IDCOMPLEXCAZARE,IDTIPURIUNITATICAZARE,NUME,PRET")] UNITATI_DE_CAZARE unitateCazare)
        {
            ViewBag.IsLoginPage = true;
            if (ModelState.IsValid)
            {
                db.Entry(unitateCazare).State = EntityState.Modified;
                db.SaveChanges();
                return View(unitateCazare);
            }
            return View(unitateCazare);
        }

        public ActionResult StergereUnitate(decimal id)
        {
            ViewBag.IsLoginPage = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UNITATI_DE_CAZARE unitateCazare = db.UNITATI_DE_CAZARE.Find(id);
            if (unitateCazare == null)
            {
                return HttpNotFound();
            }

            return View(unitateCazare);
        }

        [HttpPost, ActionName("StergereUnitate")]
        [ValidateAntiForgeryToken]
        public ActionResult StergereUnitateConfirmare(decimal id)
        {
            ViewBag.IsLoginPage = true;
            UNITATI_DE_CAZARE unitateCazare = db.UNITATI_DE_CAZARE.Find(id);
            if (unitateCazare == null)
            {
                return HttpNotFound();
            }

            db.UNITATI_DE_CAZARE.Remove(unitateCazare);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}