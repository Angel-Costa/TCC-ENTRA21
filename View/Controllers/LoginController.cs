using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Repository.Interfaces;
using Repository.Repositories;

namespace View.Controllers
{
    public class LoginController : Controller
    {
        private AdministradorRepository repositoryAdministrador;
        private ClienteRepository repositoryCliente;
        

        public LoginController()
        {
            repositoryAdministrador = new AdministradorRepository();
            repositoryCliente = new ClienteRepository();

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
            var administrador = repositoryAdministrador.VerificarLoginSenha(login, senha);
            if (administrador == null)
            {
                var usuario = repositoryCliente.VerificarLoginSenha(login, senha);
                // if (usuario == null)
                // enviar mensagem para o usuário que a senha ou login incorreto
                if (usuario == null)
                {
                    Console.WriteLine("Senha ou login está errado");
                }

                //if (privilegio == true)
                // {
                //     return RedirectoAction("Index" , "Home");
                // }
                // 
                // if (privilegio == false)
                // {
                //      return RedirectToAction("Index", "Home", "ViewCliente")
                var cookie = new HttpCookie("Usuario", usuario.Id.ToString());
                cookie.Domain = "localhost:44389";
                Response.SetCookie(cookie);
                Response.Redirect("http://localhost:44389");
                return Redirect("http://localhost:44389");
                
            }

            Session["Usuario"] = administrador;
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
            repositoryCliente.Cadastro(cliente);
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