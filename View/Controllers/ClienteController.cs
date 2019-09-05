using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.Repositories;

namespace View.Controllers
{
    [Route("cliente/")]
    public class ClienteController : Controller
    {
        private ClienteRepository repository;

        public ClienteController()
        {
            repository = new ClienteRepository();
        }

        public ActionResult Index()
        {
            List<Cliente> clientes = repository.ObterTodos();
            ViewBag.Clientes = clientes;
            return View();
        }

        public ActionResult Cadastro()
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            List<Cliente> clientes = clienteRepository.ObterTodos();
            ViewBag.Clientes = clientes;
            return View();
        }

        [HttpPost, Route("cadastro")]
        public ActionResult Cadastro(Cliente cliente)
        {
            var id = repository.Cadastro(cliente);
            return RedirectToAction("Index");
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var cliente = repository.ObterPeloId(id);
            ViewBag.Cliente = cliente;
            return View();
        }
        
        [HttpPost,Route("editar")]
        public ActionResult Editar(Cliente cliente)
        {
            var alterado = repository.Alterar(cliente);
            return RedirectToAction("Index");
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            return RedirectToAction("Index");

        }                
    }
}
