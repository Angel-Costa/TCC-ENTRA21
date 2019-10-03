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
    public class PerfilController : BaseController
    {
        private ClienteRepository repository;

        public PerfilController()
        {
            repository = new ClienteRepository();
        }
        // GET: Perfil
        public ActionResult Index()
        {
            var clienteSessao = (Cliente)Session["Cliente"];
            Cliente cliente = repository.ObterPeloId(clienteSessao.Id);

            ViewBag.Cliente = cliente;
            return View();
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var cliente = repository.ObterPeloId(id);
            ViewBag.Cliente = cliente;
            return View();
        }

        [HttpPost, Route("editar")]
        public ActionResult Editar(Cliente cliente)
        {
            List<Cliente> clientes = repository.ObterTodos();
            ViewBag.Clientes = clientes;
            var alterado = repository.Alterar(cliente);
            return RedirectToAction("Index", new { id = cliente.Id });
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

                var usuarioLogado = (Administrador)Session["Cliente"];

                Cliente cliente = repository.ObterPeloId(usuarioLogado.Id);
                cliente.Imagem = nomeImagem;
                repository.Alterar(cliente);
                Session["Cliente"] = cliente;
            }


            ViewData["Message"] = String.Format(" arquivo(s) salvo(s) com sucesso.");
            return RedirectToAction("EditarPerfil");
        }

        public ActionResult Cliente()
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            List<Cliente> clientes = repository.ObterTodos();
            ViewBag.Cliente = clientes;
            return View();
        }

    }
}