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
            List<Sugestao> sugestoes = sugestaoRepository.ObterTodos();
            ViewBag.Sugestao = sugestoes;
            return View();
        }

        [HttpPost, Route("cadastro")]
        public ActionResult Cadastro(Sugestao sugestao)
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
                sugestao.Imagem = nomeImagem;

            }


            //            ViewData["Message"] = String.Format(" arquivo(s) salvo(s) com sucesso.");


            var id = repository.Inserir(sugestao);

            return RedirectToAction("Galeria", new { id });
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var sugestao = repository.ObterPeloId(id);
            ViewBag.Sugestao = sugestao;
            return View();
        }

        [HttpPost, Route("editar")]
        public ActionResult Editar(Sugestao sugestao)
        {
            HttpPostedFileBase arquivo = Request.Files[0];

            if (arquivo.ContentLength > 0)
            {
                var uploadPath = Server.MapPath("~/Content/Uploads");
                var nomeImagem = Path.GetFileName(arquivo.FileName);
                string caminhoArquivo = Path.Combine(@uploadPath, nomeImagem);
                arquivo.SaveAs(caminhoArquivo);

                sugestao.Imagem = nomeImagem;
                var alterado2 = repository.Alterar(sugestao);
                return RedirectToAction("Galeria");
            }

            var alterado = repository.Alterar(sugestao);
            return RedirectToAction("Galeria");
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            return RedirectToAction("Galeria");
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

                var usuarioLogado = (Hotel)Session["Usuario"];

                Sugestao sugestao = repository.ObterPeloId(usuarioLogado.Id);
                sugestao.Imagem = nomeImagem;
                repository.Alterar(sugestao);
                Session["Usuario"] = sugestao;
            }


            ViewData["Message"] = String.Format(" arquivo(s) salvo(s) com sucesso.");
            return RedirectToAction("cadastro");
        }
    }
}
