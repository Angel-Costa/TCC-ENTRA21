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

        [HttpGet, Route("esquecisenha")]
        public ActionResult EsqueciSenha()
        {   
            return View();
        }

        [HttpPost, Route("esquecisenha")]
        public ActionResult EsqueciSenha(Usuario usuario)
        {
            var alterado = repository.Alterar(usuario);
            return RedirectToAction("Index");
        }
		
		public ActionResult Select()
		{
            return View();
		}

        [HttpGet,Route("administrador")]
		public ActionResult Administrador()
		{
			return View("Home");
		}

		[HttpGet,Route("usuario")]
		public ActionResult Usuario()
		{
			return View();
		}
    }
}