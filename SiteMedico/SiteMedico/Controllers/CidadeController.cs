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
    public class CidadeController : Controller
    {
        private SiteMedicoDBEntities db = new SiteMedicoDBEntities();

        public static object EstadoId { get; private set; }
        // GET: Cidade
        public ActionResult Index()
        {
            var cidades = db.Cidades.ToList();
            return View(cidades);
        }

        public ActionResult Adicionar()
        {
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Estado");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Cidades city)
        {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Estado");
            return View(city);
        }

        public ActionResult Editar(long id)
        {
            Cidades med = db.Cidades.Find(id);
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Estado");
            return View(med);
        }

        [HttpPost]
        public ActionResult Editar(Cidades med)
        {
            if (ModelState.IsValid)
            {
                db.Entry(med).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Estado");
            return View(med);
        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades med = db.Cidades.Find(id);
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
            Cidades med = db.Cidades.Find(id);
            db.Cidades.Remove(med);
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
            Cidades med = db.Cidades.Find(id);
            if (med == null)
            {
                return HttpNotFound();
            }
            return View(med);
        }
    }
}