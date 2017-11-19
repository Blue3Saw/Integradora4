using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using DAO;

namespace ProyectoUniJob.Controllers.BackEnd
{
    public class AprobarTareaController : Controller
    {
        TareasDAO dao = new TareasDAO();
        // GET: AprobarTarea
        public ActionResult Index()
        {
            return View(dao.TodasTareas2());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DatosTarea(string boton)
        {
            int dato = int.Parse(boton);
            return View(dao.TablaTareas2(dato));
        }
    }
}