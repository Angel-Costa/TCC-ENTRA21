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
        private AvaliacoesRepository repository;

        public AvaliacaoController()
        {
            repository = new AvaliacoesRepository();
        }

        // GET: Avaliacao
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Avaliacao avaliacao)
        {
            var alterou = repository.Alterar(avaliacao);
            return Json(new { status = alterou });
        }

        [HttpGet, Route("apagar/{id}")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost, Route("inserir/{id}")]
        public JsonResult Inserir(Avaliacao avaliacao)
        {
            var id = repository.Inserir(avaliacao);
            return RedirectToAction("Editar", new { id });
        }

        [HttpGet, Route("obterpeloid")]
        public JsonResult ObterPeloId(int id)
        {
            Avaliacao avaliacao = repository.ObterPeloId(id);
            return Json(avaliacao, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var avaliacao = repository.ObterTodos();
            return Json(new { data = avaliacao });
        }
    }
}