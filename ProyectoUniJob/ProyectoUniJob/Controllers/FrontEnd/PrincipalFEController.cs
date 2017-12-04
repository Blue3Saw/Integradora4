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
            InformacionDAO Info = new InformacionDAO();                      
            ViewBag.Codigo = Session["Codigo"];
            ViewBag.Informacion = Info.Datos();
            return View();
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
                return RedirectToAction("Index", "AgregarEstudiante");
            }
            else if (ObjUsuario.LoginEmpleador(Datos) > 0)
            {
                Session["Codigo"] = ObjUsuario.LoginEmpleador(Datos);
                Session["msgadm"] = 1;
                return RedirectToAction("IndexEmpleador", "Usuario");
            }
            else if (ObjUsuario.LoginEstudiante(Datos) > 0)
            {
                Session["Codigo"] = ObjUsuario.LoginEstudiante(Datos);
                Session["msgadm"] = 2;
                return RedirectToAction("IndexEstudiante", "Usuario");
                
            }
            else
            {
                Session["Codigo"] = "nulo";
                ViewBag.Codigo = Session["Codigo"];
                return RedirectToAction("Index", "PrincipalFE");
            }
        }

        public ActionResult RedireccionarAgregar()
        {
            return RedirectToAction("Redireccionar", "PrincipalFE");
        }
    }
}