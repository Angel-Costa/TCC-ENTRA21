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
            List<Comodidade> comodidades = repository.ObterTodos();
            ViewBag.Comodidades = comodidades;
            return View();
        }
        /* CategoriaRepository categoriaRepository = new CategoriaRepository();
            List<Categoria> categorias = categoriaRepository.ObterTodos();
            ViewBag.Categorias = categorias;
        */

        public ActionResult Cadastro()
        {
            List<Comodidade> comodidades = repository.ObterTodos();
            ViewBag.Comodidades = comodidades;

            HotelRepository hotelRepository = new HotelRepository();
            List<Hotel> hoteis = hotelRepository.ObterTodos();
            ViewBag.Hoteis = hoteis;
            return View();

        }

        [HttpPost, Route("inserir")]
        public ActionResult Inserir(Comodidade comodidade)
        {            
            var id = repository.Inserir(comodidade);
            return RedirectToAction("Inserir", new { id });
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var comodidade = repository.ObterPeloId(id);
            return View();
        }

        [HttpPost, Route("editar")]
        public ActionResult Editar(Comodidade comodidade)
        {
            var alterado = repository.Alterar(comodidade);
            return RedirectToAction("Editar", new { comodidade.Id });
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id); 
            return RedirectToAction("Index");
        }

    }
}