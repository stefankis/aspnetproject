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
    public class Admin_CamereController : Controller
    {
        private ProiectEntities db = new ProiectEntities();

        public ActionResult Index(decimal? capacitateSelectata = null)
        {
            ViewBag.IsLoginPage = true;

            var camere = db.CAMERE.AsQueryable();

            // Filtrare pe baza capacității, dacă este specificată
            if (capacitateSelectata.HasValue)
            {
                camere = camere.Where(c => c.CAPACITATE == capacitateSelectata.Value);
            }

            var capacitatiUnice = db.CAMERE.Select(c => c.CAPACITATE).Distinct().OrderBy(c => c).ToList();
            ViewBag.CapacitatiUnice = new SelectList(capacitatiUnice);

            return View(camere.ToList());
        }
    }
}