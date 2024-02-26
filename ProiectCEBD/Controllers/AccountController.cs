    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    namespace ProiectCEBD.Controllers
    {
        public class AccountController : Controller
        {
        // Alte acțiuni ale controller-ului


            [HttpGet]
            public ActionResult Login()
            {
                ViewBag.IsLoginPage = true;
                return View(); // Aici va returna Views/Account/Login.cshtml
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(string username, string password)
                {
                    ViewBag.IsLoginPage = true;
                    if (username == "admin" && password == "parola")
                    {
                        ViewBag.LoginMessage = "Felicitari, ati fost conectat cu succes!";
                        /// return View("~/Views/Admin_Complexuri_Cazare/AdminComplexuriCazare.cshtml"); // Specificați calea exactă așa cum este în structura de fișiere
                        return RedirectToAction("Index", "Admin_Complexuri_Cazare");
                    }
                    else
                        {
                            ViewBag.LoginError = "Datele de conectare sunt gresite. Va rugam reincercati!";
                            return View("~/Views/Account/Login.cshtml"); // Specificați calea exactă așa cum este în structura de fișiere
                        }
                    }
                }

    }