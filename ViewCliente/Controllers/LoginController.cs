using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Model;
using Repository.Interfaces;
using Repository.Repositories;

namespace View.Controllers
{
    public class LoginController : Controller
    {
        private AdministradorRepository repositoryAdministrador;
        private ClienteRepository reositoryCliente;

        public LoginController()
        {
            repositoryAdministrador = new AdministradorRepository();
            reositoryCliente = new ClienteRepository();

        }


        public ActionResult Index()
        {
            if (Session["Usuario"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string senha)
        {
            var cliente = reositoryCliente.VerificarLoginSenha(login, senha);
            // if (usuario == null)
            // enviar mensagem para o usuário que a senha ou login incorreto
            if (cliente == null)
            {
                return RedirectToAction("Index", "Login");

            }
            Session["Cliente"] = cliente;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Cliente cliente)
        {
            reositoryCliente.Cadastro(cliente);
            return RedirectToAction("Index");
        }

        [HttpGet, Route("esquecisenha")]
        public ActionResult EsqueciSenha()
        {
            return View();
        }

        [HttpPost, Route("esquecisenha")]
        public ActionResult EsqueciSenha(Administrador usuario)
        {
            var alterado = repositoryAdministrador.Alterar(usuario);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Sair()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index");
        }
    }
}