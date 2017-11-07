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
        EstatusDAO ObjPersona = new EstatusDAO();
        // GET: Prueba

        public ActionResult Index()
        {
            return View(ObjPersona.VerEstatus());
        }
    }
}