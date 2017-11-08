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
            return View("PrincipalFE");
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
                return RedirectToAction("Index", "Prueba");
            }
            else if (ObjUsuario.LoginEmpleador(Datos) > 0)
            {
                return RedirectToAction("Index2", "Prueba");
            }
            else if (ObjUsuario.LoginEstudiante(Datos) > 0)
            {
                return RedirectToAction("Index2", "Prueba");
            }
            else
            {
                return RedirectToAction("Index", "Prueba");
            }
        }
    }
}