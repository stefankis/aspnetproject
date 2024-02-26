using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProiectCEBD
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Root",
                url: "",
                defaults: new { controller = "Home", action = "RedirectToLogin" }
            );

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Account", action = "Login" }
            );

            /* Routes for Complexuri Cazare */

            routes.MapRoute(
                name: "Admin",
                url: "admin/complexuri-cazare",
                defaults: new { controller = "Admin_Complexuri_Cazare", action = "Index" }
            );

            routes.MapRoute(
                name: "ComplexCazareAdaugare",
                url: "admin/complexuri-cazare/adaugare",
                defaults: new { controller = "Admin_Complexuri_Cazare", action = "CreareComplex" }
            );

            routes.MapRoute(
                name: "ComplexCazareStergere",
                url: "admin/complexuri-cazare/{id}/delete",
                defaults: new { controller = "Admin_Complexuri_Cazare", action = "StergereComplex" }
            );

            routes.MapRoute(
                name: "ComplexCazareDetails",
                url: "admin/complexuri-cazare/{numecomplex}/",
                defaults: new { controller = "Admin_Complexuri_Cazare", action = "Details" }
            );

            routes.MapRoute(
                name: "ComplexCazareAdaugareUnitateCazare",
                url: "admin/complexuri-cazare/{complex}/adaugare-unitate-cazare",
                defaults: new { controller = "Admin_Complexuri_Cazare", action = "CreareUnitateCazare" }
            );

            routes.MapRoute(
                name: "ComplexCazareStergereUnitateCazare",
                url: "admin/complexuri-cazare/{complex}/{id}/delete",
                defaults: new { controller = "Admin_Complexuri_Cazare", action = "StergereUnitateCazare" }
            );

            routes.MapRoute(
                name: "ComplexCazareEdit",
                url: "admin/complexuri-cazare/{complex}/edit",
                defaults: new { controller = "Admin_Complexuri_Cazare", action = "EditareComplex" }
            );

            routes.MapRoute(
                name: "ComplexCazareUnitateCazareCameraDetails",
                url: "admin/complexuri-cazare/{complex}/{unitate}",
                defaults: new { controller = "Admin_Complexuri_Cazare", action = "VizualizareCamere" }
            );

            routes.MapRoute(
                name: "ComplexCazareUnitateCazareCameraCreare",
                url: "admin/complexuri-cazare/{complex}/{unitate}/adaugare-camera",
                defaults: new { controller = "Admin_Complexuri_Cazare", action = "CreareCamera" }
            );

            routes.MapRoute(
                name: "ComplexCazareUnitateCazareCameraDelete",
                url: "admin/complexuri-cazare/{complex}/{unitate}/{id}/delete",
                defaults: new { controller = "Admin_Complexuri_Cazare", action = "StergereCamera" }
            );

            routes.MapRoute(
                name: "ComplexCazareUnitateCazareEdit",
                url: "admin/complexuri-cazare/{complex}/{unitate}/edit",
                defaults: new { controller = "Admin_Complexuri_Cazare", action = "EditareUnitate" }
            );

            routes.MapRoute(
                name: "ComplexCazareUnitateCazareCameraEdit",
                url: "admin/complexuri-cazare/{complex}/{unitate}/{camera}",
                defaults: new { controller = "Admin_Complexuri_Cazare", action = "EditareCamera" }
            );

            /* End routes for Complexuri Cazare */

            /* Routes for Unitati cazare */

            routes.MapRoute(
                name: "UnitatiCazareList",
                url: "admin/unitati-cazare",
                defaults: new { controller = "Admin_Unitati_Cazare", action = "Index" }
            );

            routes.MapRoute(
                name: "UnitatiCazareEdit",
                url: "admin/unitati-cazare/{unitate}/edit",
                defaults: new { controller = "Admin_Unitati_Cazare", action = "EditareUnitate" }
            );

            routes.MapRoute(
                name: "UnitatiCazareDelete",
                url: "admin/unitati-cazare/{id}/delete",
                defaults: new { controller = "Admin_Unitati_Cazare", action = "StergereUnitate" }
            );

            routes.MapRoute(
                name: "UnitatiCazareCreare",
                url: "admin/unitati-cazare/adaugare",
                defaults: new { controller = "Admin_Unitati_Cazare", action = "CreareUnitate" }
            );

            /* End routes for Unitati Cazare */

            /* Routes for Tipuri Unitati Cazare */

            routes.MapRoute(
                name: "TipuriUnitatiCazareList",
                url: "admin/tipuri-unitati-cazare",
                defaults: new { controller = "Admin_Tipuri_Unitati_Cazare", action = "Index" }
            );

            routes.MapRoute(
                name: "TipuriUnitatiCazareEdit",
                url: "admin/tipuri-unitati-cazare/{tip_unitate}/edit",
                defaults: new { controller = "Admin_Tipuri_Unitati_Cazare", action = "EditareTipUnitate" }
            );

            routes.MapRoute(
                name: "TipuriUnitatiCazareDelete",
                url: "admin/tipuri-unitati-cazare/{id}/delete",
                defaults: new { controller = "Admin_Tipuri_Unitati_Cazare", action = "StergereTipUnitate" }
            );

            routes.MapRoute(
                name: "TipuriUnitatiCazareCreare",
                url: "admin/tipuri-unitati-cazare/adaugare",
                defaults: new { controller = "Admin_Tipuri_Unitati_Cazare", action = "CreareTipUnitate" }
            );

            /* End routes for Tipuri Unitati Cazare */

            /* Routes for Camere */

            routes.MapRoute(
                name: "CamereList",
                url: "admin/camere",
                defaults: new { controller = "Admin_Camere", action = "Index" }
            );

            /* End routes for Camere */

        }
    }
}
