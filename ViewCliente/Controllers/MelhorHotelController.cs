using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewCliente.Controllers
{
    public class MelhorHotelController : BaseController
    {
        // GET: MelhorHotel
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ConhecaSite()
        {
            return View();
        }

        public ActionResult ConhecaLux()
        {
            return View();
        }

    }
}