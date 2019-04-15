using SiteMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteMedico.Controllers
{
    public class LoginController : Controller
    {
        private SiteMedicoDBEntities db = new SiteMedicoDBEntities();

        public ActionResult Login()
        {
            ViewBag.Title = "Cadê Meu Médico? - Login";
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(Usuarios usr)
        {
            var login = db.Usuarios.FirstOrDefault(m => m.Login == usr.Login && m.Senha == usr.Senha);
            if (login != null)
            {
                HomeController.us = new UserInfo(login.UsuarioId, login.Nome, login.Login, login.Senha, login.Email);
                return RedirectToAction("../Home/Index",HomeController.us);
            }
            else
            {
                ViewBag.Message = string.Format("Digitou errado!");
                return View();
            }
        }
    }
}