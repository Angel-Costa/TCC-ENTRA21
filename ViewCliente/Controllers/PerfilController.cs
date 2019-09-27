using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewCliente.Controllers
{
    public class PerfilController : Controller
    {
        private ClienteRepository repositoryCliente;

        public PerfilController()
        {
            repositoryCliente = new ClienteRepository();
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


        }


    }
}