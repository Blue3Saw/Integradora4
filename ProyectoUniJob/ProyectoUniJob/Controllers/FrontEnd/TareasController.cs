using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;

namespace ProyectoUniJob.Controllers.FrontEnd
{
    public class TareasController : Controller
    {
        TareasDAO ObjTareas = new TareasDAO();

        // GET: Tareas
        public ActionResult Index()
        {
            return View();
        }


    }
}