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
        public ActionResult Relacionar(ClienteLogin clienteLogin)
        {
            int id = repository.Relacionar(clienteLogin);
            return RedirectToAction("Relacionar", new { clienteLogin.IdCliente});
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);

            return RedirectToAction("Index");
        }

       
    }
}