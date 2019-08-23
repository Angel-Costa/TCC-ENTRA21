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
    [Route("login/")]
    public class LoginController : Controller
    {
        private ILoginRepository repository;

        public LoginController(ILoginRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost,Route ("inserir")]
        public JsonResult Inserir(Login login)
        {
            var id = repository.Inserir(login);
            var resultado = new { id = id };
            return Json(resultado);
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado);
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var logins = repository.ObterTodos();
            return Json(new { data = logins });
        }

        [HttpGet, Route("obterpeloid")]
        public JsonResult ObterPeloId(int id)
        {
            var login = repository.ObterPeloId(id);
            
            

            return Json(login);
        }

        [HttpGet, Route("obtertodosselect2")]
        public JsonResult ObterTodosSelect2(string term = "")
        {
            term = term == null ? "" : term;

            var registros = repository.ObterTodos();
            var loginsSelect2 = new List<object>();

            foreach(var login in registros)
            {
                loginsSelect2.Add(new
                {
                    id = login.Id,
                    text = login.Email
                });
            }
            return Json(new { result = loginsSelect2 });
        }
    }
}            