﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Model;
using Repository.Interfaces;
using Repository.Repositories;

namespace View.Controllers
{
    public class AdministradorController : Controller
    {
        private AdministradorRepository repository;

        public AdministradorController()
        {
            repository = new AdministradorRepository();
        }

        public ActionResult Index()
        {            
            List<Administrador> administradores = repository.ObterTodos();
            ViewBag.Administradores = administradores;
            return View();
        }


        public ActionResult Cadastro()
        {            
            List<Administrador> administradores = repository.ObterTodos();
            ViewBag.Administradores = administradores;
            return View();
        }
        
        [HttpGet, Route("editarperfil")]
        public ActionResult EditarPerfil()
        {
            return View();
        }

        [HttpPost, Route("inserir")]
        public ActionResult Inserir(Administrador administrador)
        {
            var id = repository.Inserir(administrador);
            return RedirectToAction("Index", new { id });
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var administrador = repository.ObterPeloId(id);
            ViewBag.Administrador = administrador;
            return View();
        }

        [HttpPost, Route("editar")]
        public ActionResult Editar(Administrador administrador)
        {
            var alterado = repository.Alterar(administrador);
            ViewBag.Administrador = administrador;
            return RedirectToAction("Index", new { administrador.Id });
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet, Route("perfil")]
        public ActionResult Perfil()
        {
            Administrador administrador = repository.ObterPeloId(1);
            ViewBag.administrador = administrador;
            return View();
        }

        [HttpPost, Route("editarxd")]
        public ActionResult EditarPerfil(Administrador administrador)
        {
            var alterado = repository.Alterar(administrador);
            ViewBag.Administrador = administrador;

            return RedirectToAction("Perfil", new { administrador.Id });
        }

    }
}