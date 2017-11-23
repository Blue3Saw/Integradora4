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

        [HttpPost]
        public ActionResult Aprobar(string codigo,string boton1,string boton2)
        {
            TareasBO bo = new TareasBO();

            if (boton1 == "1")
            {
                bo.CodigoEstatus = 1;
                bo.Codigo = int.Parse(codigo);
                dao.EliminarTarea(bo);
            }
            if (boton2=="2")
            {
                bo.CodigoEstatus = 2;
                bo.Codigo = int.Parse(codigo);
                dao.EliminarTarea(bo);
            }
            Index();
            return View("Index");
        }
    }
}