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
    public class EstadosController : Controller
    {
        private SiteMedicoDBEntities db = new SiteMedicoDBEntities();

        public static object PaisId { get; private set; }
        // GET: Estados
        public ActionResult Index()
        {
            var estados = db.Estados.ToList();
            return View(estados);
        }

        public ActionResult Adicionar()
        {
            ViewBag.PaisId = new SelectList(db.Paises, "PaisId", "Pais");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Estados e)
        {
            if (ModelState.IsValid)
            {
                db.Estados.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaisId = new SelectList(db.Paises, "PaisId", "Pais", e.PaisId);
            return View(e);
        }

        public ActionResult Editar(long id)
        {
            Estados med = db.Estados.Find(id);
            ViewBag.PaisId = new SelectList(db.Paises, "PaisId", "Pais");
            return View(med);
        }

        [HttpPost]
        public ActionResult Editar(Estados med)
        {
            if (ModelState.IsValid)
            {
                db.Entry(med).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaisId = new SelectList(db.Paises, "PaisId", "Pais");
            return View(med);
        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estados med = db.Estados.Find(id);
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
            Estados med = db.Estados.Find(id);
            db.Estados.Remove(med);
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
            Estados med = db.Estados.Find(id);
            if (med == null)
            {
                return HttpNotFound();
            }
            return View(med);
        }
    }
}