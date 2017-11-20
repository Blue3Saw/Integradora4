using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;

namespace ProyectoUniJob.Controllers.BackEnd
{
    public class MesajesAdmController : Controller
    {
        MensajesDAO objMensajes = new MensajesDAO();
        // GET: MesajesAdm
        public ActionResult Index()
        {
            Session["idme"] = 2;
            return View(objMensajes.MOstarMensajes(int.Parse(Session["idme"].ToString())));
        }


        public ActionResult lol()
        {
            Session["idme"] = 2;
            return View(objMensajes.MOstarMensajes(int.Parse(Session["idme"].ToString())));
        }

        public ActionResult enviar()
        {


            Index();
            return View();
        }
    }
}