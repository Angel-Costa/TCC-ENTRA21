using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("sugestao")]
    public class SugestaoController : Controller
    {
        private SugestaoRepository repository;

        public SugestaoController()
        {
            repository = new SugestaoRepository();
        }

        public ActionResult Index()
        {
            List<Sugestao> sugestaos = repository.ObterTodos();
            ViewBag.Sugestao = sugestaos;
            return View();
        }

        public ActionResult Galeria()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            SugestaoRepository sugestaoRepository = new SugestaoRepository();
            List<Sugestao> sugestoes = repository.ObterTodos();
            ViewBag.Sugestao = sugestoes;
            return View();
        }

        [HttpPost, Route("cadastro")]
        public ActionResult Cadastro(Sugestao sugestao)
        {
            var id = repository.Cadastro(sugestao);
            return RedirectToAction("Index");
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var sugestao = repository.ObterPeloId(id);
            ViewBag.Sugestao = sugestao;
            return View();
        }

        [HttpPost, Route("editar")]
        public ActionResult Editar(Sugestao sugestao)
        {
            var alterado = repository.Alterar(sugestao);
            return RedirectToAction("Index");
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Blumenau()
        {
            HotelRepository hotelRepository = new HotelRepository();
            List<Hotel> hoteis = hotelRepository.ObterTodosPelaCidade("Blumenau");
            ViewBag.Hoteis = hoteis;
            return View();
        }

        public ActionResult Florianopolis()
        {
            HotelRepository hotelRepository = new HotelRepository();
            List<Hotel> hoteis = hotelRepository.ObterTodos();
            ViewBag.Hoteis = hoteis;
            return View();
        }

        public ActionResult SaoFrancisco()
        {
            HotelRepository hotelRepository = new HotelRepository();
            List<Hotel> hoteis = hotelRepository.ObterTodos();
            ViewBag.Hoteis = hoteis;
            return View();
        }

        public ActionResult PortoBelo()
        {
            HotelRepository hotelRepository = new HotelRepository();
            List<Hotel> hoteis = hotelRepository.ObterTodos();
            ViewBag.Hoteis = hoteis;
            return View();
        }
        public ActionResult Garopaba()
        {
            HotelRepository hotelRepository = new HotelRepository();
            List<Hotel> hoteis = hotelRepository.ObterTodos();
            ViewBag.Hoteis = hoteis;
            return View();
        }
        public ActionResult PraiaDoRosa()
        {
            HotelRepository hotelRepository = new HotelRepository();
            List<Hotel> hoteis = hotelRepository.ObterTodos();
            ViewBag.Hoteis = hoteis;
            return View();
        }
        public ActionResult NovaTrento()
        {
            HotelRepository hotelRepository = new HotelRepository();
            List<Hotel> hoteis = hotelRepository.ObterTodos();
            ViewBag.Hoteis = hoteis;
            return View();
        }
    }
}