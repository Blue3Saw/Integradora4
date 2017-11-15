using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using BO;

namespace ProyectoUniJob.Controllers.BackEnd
{
    public class PerfilAdminController : Controller
    {
        UsuariosDAO objUsuario = new UsuariosDAO();
        // GET: PerfilAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DatosPerfil()
        {
            Session["id"] = 1;
            return View(objUsuario.PerfilUsuario2(int.Parse(Session["id"].ToString())));
        }

        public ActionResult actualizar(UsuarioBO BO)
        {
            objUsuario.ActualizarUsuario(BO);
            DatosPerfil();
            return View("DatosPerfil");
        }
    }
}