using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace View.Controllers
{
    public class HotelController : Controller
    {
        private IHotelRepository repository;

        public HotelController(IHotelRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet,Route("hotel/obterTodos")]
        public JsonResult ObterTodos(Dictionary<string, string> search)
        {
            string busca = search["value"];
            if (busca == null)
                busca = "";
            List<Hotel> hotels = repository.ObterTodos();
            return Json(new { data = hotels });
        }



    }
}