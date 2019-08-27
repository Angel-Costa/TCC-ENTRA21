using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("avaliacoes")]
    public class AvaliacaoController : Controller
    {
        private IAvaliacoesRepository repository;
        public AvaliacaoController(IAvaliacoesRepository repository)
        {
            this.repository = repository;
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

        [HttpGet, Route("apagar")]
        public JsonResult Apagou(int id)
        {
            var avaliacao = repository.Apagar(id);
            return Json(new { status = avaliacao });
        }

        [HttpPost, Route("inserir")]
        public JsonResult Inserir(Avaliacao avaliacao)
        {
            var id = repository.Inserir(avaliacao);
            var resultado = new { id = id };
            return Json(resultado);
        }

        [HttpGet, Route("obterpeloid")]
        public JsonResult ObterPeloId(int id)
        {
            var avaliacao = repository.ObterPeloId(id);
            if (avaliacao == null) return NotFound();
            return Json(avaliacao);
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var avaliacao = repository.ObterTodos();
            return Json(new { data = avaliacao });
        }
    }
}