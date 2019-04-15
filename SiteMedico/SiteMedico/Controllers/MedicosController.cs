using SiteMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net;

namespace SiteMedico.Controllers
{
    public class MedicosController : Controller
    {
        private SiteMedicoDBEntities db = new SiteMedicoDBEntities();

        public static object CidadeId { get; private set; }
        public static object EspecialidadeId { get; private set; }

        // GET: Medicos
        public ActionResult Index()
        {
            var medico = db.Medicos.Include(m => m.Cidades).Include(m => m.Especialidades).ToList();
            return View(medico);
        }

        public ActionResult Adicionar()
        {
            ViewBag.CidadeId = new SelectList(db.Cidades, "CidadeId", "Cidade");
            ViewBag.EspecialidadeId = new SelectList(db.Especialidades, "EspecialidadeId", "Especialidade");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medicos med)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(med);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCidade = new SelectList(db.Cidades, "CidadeId", "Cidade", med.CidadeId);
            ViewBag.IdEspecialidade = new SelectList(db.Especialidades, "EspecialidadeId", "Especialidade");
            return View(med);
        }

        public ActionResult Editar(long id)
        {
            Medicos med = db.Medicos.Find(id);
            ViewBag.CidadeId = new SelectList(db.Cidades, "CidadeId", "Cidade");
            ViewBag.EspecialidadeId = new SelectList(db.Especialidades, "EspecialidadeId", "Especialidade");
            return View(med);
        }

        [HttpPost]
        public ActionResult Editar(Medicos med)
        {
            if (ModelState.IsValid)
            {
                db.Entry(med).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCidade = new SelectList(db.Cidades, "CidadeId", "Cidade", med.CidadeId);
            ViewBag.IdEspecialidade = new SelectList(db.Especialidades, "EspecialidadeId", "Especialidade");
            return View(med);
        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos med = db.Medicos.Find(id);
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
            Medicos med = db.Medicos.Find(id);
            db.Medicos.Remove(med);
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
            Medicos med = db.Medicos.Find(id);
            if (med == null)
            {
                return HttpNotFound();
            }
            return View(med);
        }
    }
}