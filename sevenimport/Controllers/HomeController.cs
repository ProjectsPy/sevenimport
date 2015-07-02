using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sevenimport;
using sevenimport.ModelsViews;


namespace sevenimport.Controllers
{
    public class HomeController : Controller
    {
        private importEntities db = new importEntities();

        public ActionResult Index()
        {
            var viewModels = new IndexPortada();

            viewModels.Quienes = db.quienes;
            viewModels.Partners = db.partners;
            viewModels.Services = db.services;
            viewModels.Sliders = db.sliders;


            return View(viewModels);




        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Admin()
        {
            ViewBag.Message = "Your Admin page.";

            return View();
        }
    }
}