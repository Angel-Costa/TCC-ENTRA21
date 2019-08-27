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
    [Route("comodidade")]
    public class ComodidadeController : Controller
    {
        private ComodidadeRepository repository;
        public ComodidadeController()
        {
            repository = new ComodidadeRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagou(int id)
        {
            var apagou = repository.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost, Route("inserir")]
        public  ActionResult Inserir(Comodidade comodidade)
        {
            var id = repository.Inserir(comodidade);
            return RedirectToAction("Editar", new { id });
        }

    }
}