using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewCliente.Controllers
{
    public class PerfilController : Controller
    {
        private ClienteRepository repository;

        public PerfilController()
        {
            ClienteRepository repositoryCliente = new ClienteRepository();
        }
        // GET: Perfil
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Editar()
        {
            return View();
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

                var usuarioLogado = (Administrador)Session["Usuario"];

                Cliente cliente = repository.ObterPeloId(usuarioLogado.Id);
                cliente.Imagem = nomeImagem;
                repository.Alterar(cliente);
                Session["Usuario"] = cliente;
            }


            ViewData["Message"] = String.Format(" arquivo(s) salvo(s) com sucesso.");
            return RedirectToAction("EditarPerfil");
        }



    }
}