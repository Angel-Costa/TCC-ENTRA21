using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Model;
using Repository.Interfaces;
using Repository.Repositories;

namespace View.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioRepository repository;

        public LoginController()
        {
            repository = new UsuarioRepository();
        }

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Cadastro(Usuario usuario)
        {
            repository.Inserir(usuario);
            return RedirectToAction("Index");
        }



    }
}