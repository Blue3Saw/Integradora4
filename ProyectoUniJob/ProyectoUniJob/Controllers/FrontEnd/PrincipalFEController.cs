using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoUniJob.Controllers.FrontEnd
{
    public class PrincipalFEController : Controller
    {
        // GET: PrincipalFE
        public ActionResult Index()
        {
            return View("PrincipalFE");
        }
    }
}