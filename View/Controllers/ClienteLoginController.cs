using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.Repositories;

namespace View.Controllers
{

    public class ClienteLoginController : Controller
    {
        private ClienteLoginRepository repository;

        public ClienteLoginController()
        {
            repository = new ClienteLoginRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost, Route("inserir")]
        public ActionResult Inserir(Cliente cliente)
        {
            var id = repository.Inserir(cliente);
            return RedirectToAction("Editar", new { id });
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var cliente = repository.ObterPeloId(id);
            return View();
        }

        [HttpPost, Route("editar")]
        public ActionResult Editar(Cliente cliente)
        {
            var alterado = repository.Alterar(cliente);
            return RedirectToAction("Editar", new { cliente.Id });
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);

            return RedirectToAction("Index");


        }
    }
}