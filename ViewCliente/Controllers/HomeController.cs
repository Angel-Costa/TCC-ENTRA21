using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewCliente.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blumenau()
        {
            HotelRepository hotelRepository = new HotelRepository();
            List<Hotel> hoteis= hotelRepository.ObterTodos();
            ViewBag.Hoteis = hoteis;
            return View();
        }

        public ActionResult Perfil()
        {
            return View();
        }
    }
}