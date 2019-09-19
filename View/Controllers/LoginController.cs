﻿using System;
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
            if(Session["Usuario"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string senha)
        {
            var administrador = repositoryAdministrador.VerificarLoginSenha(login, senha);
            if(administrador == null)
            {
                return RedirectToAction("Index");
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
			        						
    }
}