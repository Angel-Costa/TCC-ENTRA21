using Model;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class AvaliacaoController : Controller
    {
        private AvaliacaoRepository repository;

        public AvaliacaoController()
        {
            repository = new AvaliacaoRepository();
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
        public ActionResult Inserir(Avaliacao avaliacao)
        {
            var id = repository.Inserir(avaliacao);
            return RedirectToAction("Editar", new { id });
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var hotel = repository.ObterPeloId(id);
            return View();
        }

        [HttpPost, Route("editar")]
        public ActionResult Editar(Avaliacao avaliacao)
        {
            var alterado = repository.Alterar(avaliacao);
            return RedirectToAction("Editar", new { avaliacao.Id });
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);

            return RedirectToAction("Index");
        }

    }
}