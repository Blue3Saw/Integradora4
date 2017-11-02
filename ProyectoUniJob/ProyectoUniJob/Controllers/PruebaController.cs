using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using DAO;

namespace ProyectoUniJob.Controllers
{
    public class PruebaController : Controller
    {
        PruebaDAO ObjPersona = new PruebaDAO();
        // GET: Prueba

        public ActionResult Index()
        {
            return View(ObjPersona.VerTabla());
        }
    }
}