﻿using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("sugestao")]
    public class SugestaoController : Controller
    {
        private SugestaoRepository repository;

        public SugestaoController()
        {
            repository = new SugestaoRepository();
        }

        public ActionResult Index()
        {
            List<Sugestao> sugestaos = repository.ObterTodos();
            ViewBag.Sugestao = sugestaos;
            return View();
        }

        public ActionResult Cadastro()
        {
            SugestaoRepository sugestaoRepository = new SugestaoRepository();
            List<Sugestao> sugestaos = repository.ObterTodos();
            ViewBag.Sugestao = sugestaos;
            return View();
        }

        [HttpPost,Route("cadastro")]
        public ActionResult Cadastro(Sugestao sugestao)
        {
            var id = repository.Cadastro(sugestao);
            return RedirectToAction("Index");
        }

        [HttpGet,Route("editar")]
        public ActionResult Editar(int id)
        {
            var sugestao = repository.ObterPeloId(id);
            ViewBag.Sugestao = sugestao;
            return View();
        }

        [HttpPost,Route("editar")]
        public ActionResult Editar(Sugestao sugestao)
        {
            var alterado = repository.Alterar(sugestao);
            return RedirectToAction("Index");
        }

        [HttpGet,Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}