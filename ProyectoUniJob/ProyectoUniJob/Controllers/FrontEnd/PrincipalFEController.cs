using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using DAO;

namespace ProyectoUniJob.Controllers.FrontEnd
{
    public class PrincipalFEController : Controller
    {
        UsuariosDAO ObjUsuario = new UsuariosDAO();

        // GET: PrincipalFE
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Contraseña)
        {
            UsuarioBO Datos = new UsuarioBO();
            Datos.Email = Email;
            Datos.Contraseña = Contraseña;
            if (ObjUsuario.LoginAdministrador(Datos) > 0)
            {
                Session["Codigo"] = ObjUsuario.LoginAdministrador(Datos);

                Session["Nombre"] =ObjUsuario.Buscarnombre(Datos);
                return RedirectToAction("Index", "Prueba");

                return RedirectToAction("IndexEstudiante", "Usuario");

                return RedirectToAction("Index", "AgregarEstudiante");
            }
            else if (ObjUsuario.LoginEmpleador(Datos) > 0)
            {
                Session["Codigo"] = ObjUsuario.LoginEmpleador(Datos);
                return RedirectToAction("IndexEmpleador", "Usuario");
            }
            else if (ObjUsuario.LoginEstudiante(Datos) > 0)
            {
                Session["Codigo"] = ObjUsuario.LoginEstudiante(Datos);
                return RedirectToAction("IndexEstudiante", "Usuario");
            }
            else
            {
                return RedirectToAction("Index", "PrincipalFE");
            }
        }

        public ActionResult RedireccionarAgregar()
        {
            return RedirectToAction("Redireccionar", "PrincipalFE");
        }
    }
}