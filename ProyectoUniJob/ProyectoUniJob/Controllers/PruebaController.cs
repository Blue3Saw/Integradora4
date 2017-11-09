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
        TipoUsuarioDAO ObjTipo = new TipoUsuarioDAO();
        // GET: Prueba

        public ActionResult Index()
        {
            return View(ObjPersona.VerEstatus());
        }

        public ActionResult Index2()
        {
            return View(ObjTipo.VerTipoUs());
        }

        public ActionResult Index3()
        {
            return View(ObjTipo.VerTipoUs());
        }
    }
}