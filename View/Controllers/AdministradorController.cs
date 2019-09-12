using System;
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
			AdministradorRepository administradorRepository = new AdministradorRepository();
			List<Administrador> administradores = administradorRepository.ObterTodos();
			ViewBag.Administradores = administradores;
			return View();
		}


		public ActionResult Cadastro()
		{
			List<Administrador> administradores = repository.ObterTodos();
			ViewBag.Administradores = administradores;
			return View();
		}

		[HttpPost, Route("inserir")]
		public ActionResult Inserir(Administrador administrador)
		{
			var id = repository.Inserir(administrador);
			return RedirectToAction("Editar", new { id });
		}

		[HttpGet, Route("editar")]
		public ActionResult Editar(int id)
		{
			var administrador = repository.ObterPeloId(id);
			return View();
		}

		[HttpPost, Route("editar")]
		public ActionResult Editar(Administrador administrador)
		{
			var alterado = repository.Alterar(administrador);
			return RedirectToAction("Editar", new { administrador.Id });
		}

		[HttpGet, Route("apagar")]
		public ActionResult Apagar(int id)
		{
			var apagou = repository.Apagar(id);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Perfil()
		{
			Administrador administrador = repository.ObterPeloId(1);
			ViewBag.administrador = administrador;
			return View();
		}

	}
}