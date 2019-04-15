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
    public class EspecialidadeController : Controller
    {
        private SiteMedicoDBEntities db = new SiteMedicoDBEntities();
        
        // GET: Cidade
        public ActionResult Index()
        {
            var especialidades = db.Especialidades.ToList();
            return View(especialidades);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Especialidades e)
        {
            if (ModelState.IsValid)
            {
                db.Especialidades.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }

        public ActionResult Editar(long id)
        {
            Especialidades med = db.Especialidades.Find(id);
            return View(med);
        }

        [HttpPost]
        public ActionResult Editar(Especialidades med)
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
            Especialidades med = db.Especialidades.Find(id);
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
            Especialidades med = db.Especialidades.Find(id);
            db.Especialidades.Remove(med);
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
            Especialidades med = db.Especialidades.Find(id);
            if (med == null)
            {
                return HttpNotFound();
            }
            return View(med);
        }
    }
}