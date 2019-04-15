using SiteMedico.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SiteMedico.Controllers
{
    public class PaisesController : Controller
    {
        private SiteMedicoDBEntities db = new SiteMedicoDBEntities();
        
        // GET: Paises
        public ActionResult Index()
        {
            var pais = db.Paises.ToList();
            return View(pais);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Paises p)
        {
            if (ModelState.IsValid)
            {
                db.Paises.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public ActionResult Editar(long id)
        {
            Paises med = db.Paises.Find(id);
            return View(med);
        }

        [HttpPost]
        public ActionResult Editar(Paises med)
        {
            if (ModelState.IsValid)
            {
                db.Entry(med).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(med);
        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paises med = db.Paises.Find(id);
            if (med == null)
            {
                return HttpNotFound();
            }
            return View(med);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            Paises med = db.Paises.Find(id);
            db.Paises.Remove(med);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paises med = db.Paises.Find(id);
            if (med == null)
            {
                return HttpNotFound();
            }
            return View(med);
        }
    }
}