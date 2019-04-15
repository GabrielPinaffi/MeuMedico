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
    public class UsuariosController : Controller
    {
        private SiteMedicoDBEntities db = new SiteMedicoDBEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usus = db.Usuarios.ToList();
            return View(usus);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(u);
        }

        public ActionResult Editar(long id)
        {
            Usuarios med = db.Usuarios.Find(id);
            return View(med);
        }

        [HttpPost]
        public ActionResult Editar(Usuarios med)
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
            Usuarios med = db.Usuarios.Find(id);
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
            Usuarios med = db.Usuarios.Find(id);
            db.Usuarios.Remove(med);
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
            Usuarios med = db.Usuarios.Find(id);
            if (med == null)
            {
                return HttpNotFound();
            }
            return View(med);
        }
    }
}