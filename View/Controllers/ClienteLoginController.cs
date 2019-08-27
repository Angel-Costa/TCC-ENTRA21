using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.Repositories;

namespace View.Controllers
{
    
    public class ClienteLoginController : Controller
    {
        private ClienteLoginRepository repository;

        public ClienteLoginController()
        {
            repository = new ClienteLoginRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("relacionar")]
        public JsonResult Relacionar(ClienteLogin clienteLogin)
        {
            int id = repository.Relacionar(clienteLogin);
            return Json(new { id });
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            bool apagou = repository.Apagar(int id);
            return Json(new { status = apagou });
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodosPeloIdCliente(int idCliente)
        {
            return Json(new { data = repository.ObterTodosPeloIdCliente(idCliente) });
        }
    }
}