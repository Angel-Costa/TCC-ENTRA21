﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewCliente.Controllers
{
    public class SobreNosController : BaseController
    {
        // GET: SobreNos
        public ActionResult Index()
        {
            return View();
        }
    }
}