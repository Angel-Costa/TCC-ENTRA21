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
    [Route("hotel")]
    public class HotelController : Controller
    {
        private HotelRepository repository;

        public HotelController()
        {
            repository = new HotelRepository();
        }

        public ActionResult Index()
        {
            List<Hotel> hoteis = repository.ObterTodos();
            ViewBag.Hoteis = hoteis;
            return View();
        }

        public ActionResult Cadastro()
        {
            List<Hotel> hoteis = repository.ObterTodos();
            ViewBag.Hoteis = hoteis;
            return View();
        }

        [HttpPost, Route("cadastro")]
        public ActionResult Cadastro(Hotel hotel)
        {
            var id = repository.Inserir(hotel);
            return RedirectToAction("Editar", new { id });
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var hotel= repository.ObterPeloId(id);
            return View();
        }

        [HttpPost, Route("editar")]
        public ActionResult Editar(Hotel hotel)
        {
            var alterado = repository.Alterar(hotel);
            return RedirectToAction("Editar", new { hotel.Id });
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);

            return RedirectToAction("Index");
        }
    }
}