using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    [Route("sugestao")]
    public class SugestaoController : BaseController
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

        public ActionResult Galeria()
        {
            List<Sugestao> sugestaos = repository.ObterTodos();
            ViewBag.Sugestoes = sugestaos;  
            return View();
        }

        public ActionResult Cadastro()
        {
            SugestaoRepository sugestaoRepository = new SugestaoRepository();
            List<Sugestao> sugestoes = repository.ObterTodos();
            ViewBag.Sugestao = sugestoes;
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

        public ActionResult Upload()
        {

            HttpPostedFileBase arquivo = Request.Files[0];

            //Suas validações ......

            //Salva o arquivo
            if (arquivo.ContentLength > 0)
            {
                var uploadPath = Server.MapPath("~/Content/Uploads");
                var nomeImagem = Path.GetFileName(arquivo.FileName);

                string caminhoArquivo = Path.Combine(@uploadPath, nomeImagem);

                arquivo.SaveAs(caminhoArquivo);

                var usuarioLogado = (Sugestao)Session["Usuario"];

                Sugestao sugestao = repository.ObterPeloId(usuarioLogado.Id);
                sugestao.Imagem = nomeImagem;
                repository.Alterar(sugestao);
                Session["Usuario"] = sugestao;
            }


            ViewData["Message"] = String.Format(" arquivo(s) salvo(s) com sucesso.");
            return RedirectToAction("Galeria");
        }
    }
}