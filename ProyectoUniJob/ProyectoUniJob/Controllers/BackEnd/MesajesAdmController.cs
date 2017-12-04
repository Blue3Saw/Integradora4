using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using BO;

namespace ProyectoUniJob.Controllers.BackEnd
{
    public class MesajesAdmController : Controller
    {
        MensajesDAO objMensajes = new MensajesDAO();
        MensajesBO bo = new MensajesBO();
        // GET: MesajesAdm
        public ActionResult Index()
        {
            return View(objMensajes.MOstarMensajes(int.Parse(Session["Codigo"].ToString())));
        }


        public ActionResult lol()
        {
            Session["idme"] = 1012;
            return View(objMensajes.MOstarMensajes(int.Parse(Session["idme"].ToString())));
        }

        [HttpPost]
        public ActionResult enviar(string nombre,string Titulo,string Mensaje,string id)
        {
            bo.HoraFecha = DateTime.Now;
            bo.Mensaje = Mensaje;
            bo.UsRecibe = int.Parse(nombre);
            bo.UsEnvia = int.Parse(Session["Codigo"].ToString());
            bo.idmensaje = int.Parse(id);
            bo.Titulo = Titulo;
            objMensajes.actualizarestatus(bo);
            objMensajes.AgregarMensaje(bo);
            Index();
            return View("Index");
        }
    }
}