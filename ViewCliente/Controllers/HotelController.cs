using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Model;
using Repository.Interfaces;
using Repository.Repositories;

namespace View.Controllers
{
    [Route("hotel")]
    public class HotelController : Controller
    {
        private HotelRepository repository;

        public HotelController()
        {
            repository = new HotelRepository();
        }

        public ActionResult Index()
        {
            List<Hotel> hoteis = repository.ObterTodos();
            ViewBag.Hoteis = hoteis;
            return View();
        }
        /* CategoriaRepository categoriaRepository = new CategoriaRepository();
            List<Categoria> categorias = categoriaRepository.ObterTodos();
            ViewBag.Categorias = categorias;
        */


        public ActionResult Cadastro()
        {
            HotelRepository hotelRepository = new HotelRepository();
            List<Hotel> hoteis = hotelRepository.ObterTodos();
            ViewBag.Hoteis = hoteis;
            return View();
        }

        [HttpPost, Route("cadastro")]
        public ActionResult Cadastro(Hotel hotel)
        {
            var id = repository.Inserir(hotel);
            return RedirectToAction("Index", new { id });

        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var hotel = repository.ObterPeloId(id);
            ViewBag.Hotel = hotel;
            return View();
        }

        [HttpPost, Route("editar")]
        public ActionResult Editar(Hotel hotel)
        {
            var alterado = repository.Alterar(hotel);
            return RedirectToAction("Index");
        }

        [HttpGet, Route("apagar")]
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

                var usuarioLogado = (Hotel)Session["Usuario"];

                Hotel hotel = repository.ObterPeloId(usuarioLogado.Id);
                hotel.Imagem = nomeImagem;
                repository.Alterar(hotel);
                Session["Usuario"] = hotel;
            }


            ViewData["Message"] = String.Format(" arquivo(s) salvo(s) com sucesso.");
            return RedirectToAction("Sugestao");
        }
    }
}