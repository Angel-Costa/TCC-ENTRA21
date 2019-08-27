using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Model;
using Repository.Interfaces;
using Repository.Repositories;

namespace View.Controllers
{
    public class LoginController : Controller
    {
        private LoginRepository repository;

        public LoginController()
        {
            repository = new LoginRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost,Route ("inserir")]
        public ActionResult Inserir(Login login)
        {
            var id = repository.Inserir(login);
            return RedirectToAction("Editar", new { id });
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var login = repository.ObterPeloId(id);
            return View();
        }


        [HttpPost, Route("editar")]
        public ActionResult Editar(Login login)
        {
            var alterado = repository.Alterar(login);
            return RedirectToAction("Editar", new { login.Id });
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);

            return RedirectToAction("index");
        }

    }
}            