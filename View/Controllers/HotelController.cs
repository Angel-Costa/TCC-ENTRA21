using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.Interfaces;

namespace View.Controllers
{
    public class HotelController : Controller
    {
        private IHotelRepository repository;

        public HotelController(IHotelRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("hotel/obterTodos")]
        public JsonResult ObterTodos(Dictionary<string, string> search)
        {
            string busca = search["value"];
            if (busca == null)
                busca = "";
            List<Hotel> hoteis = repository.ObterTodos();
            return Json(new { data = hoteis });
        }



    }
}