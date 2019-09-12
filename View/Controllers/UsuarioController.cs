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
    public class UsuarioController : Controller
    {
        private UsuarioRepository repository;

        public UsuarioController()
        {
            repository = new UsuarioRepository();
        }

        public ActionResult Index()
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            List<Usuario> usuarios = usuarioRepository.ObterTodos();
            ViewBag.Usuarios = usuarios;
            return View();
        }


        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost, Route("inserir")]
        public ActionResult Inserir(Usuario usuario)
        {
            var id = repository.Inserir(usuario);
            return RedirectToAction("Editar", new { id });
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var usuario = repository.ObterPeloId(id);
            return View();
        }

        [HttpPost, Route("editar")]
        public ActionResult Editar(Usuario usuario)
        {
            var alterado = repository.Alterar(usuario);
            return RedirectToAction("Editar", new { usuario.Id });
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Perfil()
        {
            Usuario usuario = repository.ObterPeloId(1);
            ViewBag.Usuario = usuario;
            
            return View();
        }

    }
}