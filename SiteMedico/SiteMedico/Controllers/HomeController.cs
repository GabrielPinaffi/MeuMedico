using SiteMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteMedico.Controllers
{
    public class HomeController : Controller
    {
        private SiteMedicoDBEntities db = new SiteMedicoDBEntities();
        public static UserInfo us = new UserInfo();


        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Cadê Meu Médico?";
            return View();
        }
    }
}