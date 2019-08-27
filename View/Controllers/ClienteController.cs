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
    [Route("cliente/")]
    public class ClienteController : Controller
    {
        private IClienteRepository repository;

        public ClienteController(IClienteRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("cadastro")]
        public ActionResult Cadastro(Cliente cliente)
        {
            var id = repository.Inserir(cliente);
            return RedirectToAction("Editar", new { id = id });
        }

        [HttpPost, Route("alterar")]
        public JsonResult Alterar([FromForm]Cliente cliente)
        {
            var alterou = repository.Alterar(cliente);
            return Json(new { status = alterou });
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagou(int id)
        {
            var apagaou = repository.Apagar(id);
            return Json(new { status = apagaou });
        }

        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var cliente = repository.ObterPeloId(id);
            if (cliente == null) return NotFound();
            return Json(cliente);
        }

        [HttpGet, Route("obtertodos")]
        public ActionResult ObterTodos()
        {
            return Json(new { data = repository.ObterTodos() });
        }

        [HttpGet, Route("cadastro")]
        public ActionResult Cadastro()
        {
            return View();
        }

    }
}

        
            
        
    
