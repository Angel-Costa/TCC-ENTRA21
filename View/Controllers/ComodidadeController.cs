using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("comodidade")]
    public class ComodidadeController : Controller
    {
        private IComodidadeRepository repository;
        public ComodidadeController(IComodidadeRepository repository)
        {
            this.repository = repository;
        }

        // GET: Comodidade
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("alterar")]
        public JsonResult Alterar( Comodidade comodidade)
        {
            var alterou = repository.Alterar(comodidade);
            return Json(new { status = alterou });
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagou(int id)
        {
            var apagou = repository.Apagar(id);
            return Json(new { status = apagou });
        }

        [HttpPost, Route("inserir")]
        public JsonResult Inserir(Comodidade comodidade)
        {
            var id = repository.Inserir(comodidade);
            var resultado = new { id = id };
            return Json(resultado);
        }

        [HttpGet, Route("obterpeloid")]
        public JsonResult ObterPeloId(int id)
        {
            var comodidade = repository.ObterPeloId(id);
            if (comodidade == null) return NotFound();

            return Json(comodidade);
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var comodidade = repository.ObterTodos();
            return Json(new { data = comodidade });
        }
    }
}