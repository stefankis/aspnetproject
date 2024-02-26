using ProiectCEBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace ProiectCEBD.Controllers
{
    public class Admin_Complexuri_CazareController : Controller
    {
        private ProiectEntities db = new ProiectEntities();

        public ActionResult Index()
        {
            ViewBag.IsLoginPage = true;
            return View(db.COMPLEX_CAZARE.ToList());
        }

        public ActionResult Details(string numecomplex, decimal? id)
        {
            ViewBag.IsLoginPage = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPLEX_CAZARE complexCazare = db.COMPLEX_CAZARE.Find(id);
            if (complexCazare == null)
            {
                return HttpNotFound();
            }
            var unitatiCazare = db.UNITATI_DE_CAZARE.Where(t => t.IDCOMPLEXCAZARE == id).ToList();

            // Trimiteți informațiile către view
            ViewBag.UnitatiDeCazare = unitatiCazare;

            return View(complexCazare);
        }

        public ActionResult CreareComplex()
        {
            ViewBag.IsLoginPage = true;

            var ultimulId = db.COMPLEX_CAZARE.Max(t => (decimal?)t.IDCOMPLEXCAZARE) ?? 0;
            var urmatorulId = Convert.ToInt32(ultimulId) + 1;

            var model = new COMPLEX_CAZARE
            {
                IDCOMPLEXCAZARE = Convert.ToInt32(urmatorulId)
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreareComplex([Bind(Include = "IDCOMPLEXCAZARE, DENUMIRE, ADRESA, EMAIL, TELEFON")] COMPLEX_CAZARE complexCazare)
        {
            ViewBag.IsLoginPage = true;
            if (ModelState.IsValid)
            {
                db.COMPLEX_CAZARE.Add(complexCazare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complexCazare);
        }

        public ActionResult VizualizareCamere(string complex, string unitate, decimal? idUnitate)
        {
            ViewBag.IsLoginPage = true;
            if (idUnitate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UNITATI_DE_CAZARE unitateCazare = db.UNITATI_DE_CAZARE.Find(idUnitate);
            if (unitateCazare == null)
            {
                return HttpNotFound();
            }
            var camereUnitate = db.CAMERE.Where(t => t.IDUNITATICAZARE == idUnitate).ToList();
            string denumireUnitate = db.UNITATI_DE_CAZARE.Find(idUnitate).NUME.ToString();
            // Trimiteți informațiile către view
            ViewBag.IDComplex = unitateCazare.IDCOMPLEXCAZARE;
            ViewBag.DenumireComplex = complex;
            ViewBag.CamereUnitate = camereUnitate;
            ViewBag.DenumireUnitate = denumireUnitate;

            return View(unitateCazare);
        }

        public ActionResult EditareCamera(string complex, string unitate, string camera, decimal id)
        {
            ViewBag.IsLoginPage = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMERE cameraUnitate = db.CAMERE.Find(id);
            if (cameraUnitate == null)
            {
                return HttpNotFound();
            }

            ViewBag.IDUnitate = cameraUnitate.IDUNITATICAZARE;
            ViewBag.DenumireComplex = complex;
            ViewBag.DenumireUnitate = unitate;

            return View(cameraUnitate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditareCamera([Bind(Include = "IDCAMERA, IDUNITATICAZARE, DENUMIRE,CAPACITATE,DISPONIBILITATE")] CAMERE cameraUnitate)
        {
            ViewBag.IsLoginPage = true;
            if (ModelState.IsValid)
            {
                db.Entry(cameraUnitate).State = EntityState.Modified;
                db.SaveChanges();
                return View(cameraUnitate);
            }
            return View(cameraUnitate);
        }

        public ActionResult EditareUnitate(string complex, string unitate, decimal id)
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
            ViewBag.DenumireComplex = complex;

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

        public ActionResult EditareComplex(string complex, decimal id)
        {
            ViewBag.IsLoginPage = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPLEX_CAZARE complexCazare = db.COMPLEX_CAZARE.Find(id);
            if (complexCazare == null)
            {
                return HttpNotFound();
            }

            ViewBag.IDComplex = complexCazare.IDCOMPLEXCAZARE;
            ViewBag.DenumireComplex = complex;

            return View(complexCazare);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditareComplex([Bind(Include = "IDCOMPLEXCAZARE, DENUMIRE, ADRESA, EMAIL, TELEFON")] COMPLEX_CAZARE complexCazare)
        {
            ViewBag.IsLoginPage = true;
            if (ModelState.IsValid)
            {
                db.Entry(complexCazare).State = EntityState.Modified;
                db.SaveChanges();
                return View(complexCazare);
            }
            return View(complexCazare);
        }

        public ActionResult StergereComplex(decimal id)
        {
            ViewBag.IsLoginPage = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPLEX_CAZARE complexCazare = db.COMPLEX_CAZARE.Find(id);
            if (complexCazare == null)
            {
                return HttpNotFound();
            }

            return View(complexCazare);
        }

        [HttpPost, ActionName("StergereComplex")]
        [ValidateAntiForgeryToken]
        public ActionResult StergereComplexConfirmare(decimal id)
        {
            ViewBag.IsLoginPage = true;
            COMPLEX_CAZARE complexCazare = db.COMPLEX_CAZARE.Find(id);
            if (complexCazare == null)
            {
                return HttpNotFound();
            }

            db.COMPLEX_CAZARE.Remove(complexCazare);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult CreareUnitateCazare(decimal id)
        {
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

            string complexCazare = db.COMPLEX_CAZARE.Find(id).DENUMIRE.ToString();

            var model = new UNITATI_DE_CAZARE
            {
                IDUNITATICAZARE = Convert.ToInt32(urmatorulId),
                IDCOMPLEXCAZARE = Convert.ToInt32(id),
            };

            ViewBag.DenumireComplex = complexCazare;
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreareUnitateCazare([Bind(Include = "IDUNITATICAZARE,IDCOMPLEXCAZARE,IDTIPURIUNITATICAZARE,NUME,PRET")] UNITATI_DE_CAZARE unitateCazare)
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

        public ActionResult CreareCamera(decimal id)
        {
            ViewBag.IsLoginPage = true;
            var ultimulId = db.CAMERE.Max(t => (decimal?)t.IDCAMERA) ?? 0;
            var urmatorulId = Convert.ToInt32(ultimulId) + 1;

            var idComplex = db.UNITATI_DE_CAZARE.Find(id).IDCOMPLEXCAZARE;

            string complexCazare = db.COMPLEX_CAZARE.Find(idComplex).DENUMIRE.ToString();
            string unitateCazare = db.UNITATI_DE_CAZARE.Find(id).NUME.ToString();
            
            var model = new CAMERE
            {
                IDCAMERA = Convert.ToInt32(urmatorulId),
                IDUNITATICAZARE = Convert.ToInt32(id)
            };

            ViewBag.DenumireComplex = complexCazare;
            ViewBag.DenumireUnitate = unitateCazare;
            ViewBag.IDComplex = idComplex;
            ViewBag.IDUnitate = id;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreareCamera([Bind(Include = "IDCAMERA, IDUNITATICAZARE, DENUMIRE, CAPACITATE, DISPONIBILITATE")] CAMERE camera)
        {
            ViewBag.IsLoginPage = true;
            if (ModelState.IsValid)
            {
                db.CAMERE.Add(camera);
                db.SaveChanges();

                var unitateCazare = db.UNITATI_DE_CAZARE.Find(camera.IDUNITATICAZARE);
                if (unitateCazare != null)
                {
                    var complexCazare = db.COMPLEX_CAZARE.Find(unitateCazare.IDCOMPLEXCAZARE);
                    if (complexCazare != null)
                    {
                        var numeComplex = complexCazare.DENUMIRE.Replace(" ", "-").ToString();
                        var numeUnitate = unitateCazare.NUME.Replace(" ", "-").ToString();

                        // Redirecționare cu parametrii corecți
                        return RedirectToAction("VizualizareCamere", "Admin_Complexuri_Cazare",
                            new { complex = numeComplex, unitate = numeUnitate, idUnitate = camera.IDUNITATICAZARE });
                    }
                }
            }

            return View(camera);
        }

        public ActionResult StergereUnitateCazare(decimal id)
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

        [HttpPost, ActionName("StergereUnitateCazare")]
        [ValidateAntiForgeryToken]
        public ActionResult StergereUnitateCazareConfirmare(decimal id)
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

        public ActionResult StergereCamera(decimal id)
        {
            ViewBag.IsLoginPage = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMERE camera = db.CAMERE.Find(id);
            if (camera == null)
            {
                return HttpNotFound();
            }

            return View(camera);
        }

        [HttpPost, ActionName("StergereCamera")]
        [ValidateAntiForgeryToken]
        public ActionResult StergereCameraConfirmare(decimal id)
        {
            ViewBag.IsLoginPage = true;
            CAMERE camera = db.CAMERE.Find(id);
            if (camera == null)
            {
                return HttpNotFound();
            }

            db.CAMERE.Remove(camera);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}