using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BO;
using DAO;
using System.Data.SqlClient;

namespace ProyectoUniJob.Controllers.FrontEnd
{
    public class UsuarioController : Controller
    {
        UsuariosDAO ObjUsuario = new UsuariosDAO();

        // GET: Usuario
        public ActionResult IndexEmpleador()
        {
            return View("IndexEmpleador");
        }

        public ActionResult IndexEstudiante()
        {
            if (Session["Codigo"] != null)
            {
                return View("IndexEstudiante");
            }
            else
            {
                return RedirectToAction("Index", "PrincipalFE");
            }
            
        }

        public ActionResult Redireccionar()
        {
            return View("Redireccionar");
        }

        public ActionResult AgregarEmp(string Nombre, string Apellidos, DateTime FechaNac, long Telefono, string Email, string Contraseña)
        {
            UsuarioBO Datos = new UsuarioBO();
            Datos.Nombre = Nombre;
            Datos.Apellidos = Apellidos;
            Datos.FechaNac = FechaNac;
            Datos.Telefono = Telefono;
            Datos.Email = Email;
            Datos.Contraseña = Contraseña;
            Datos.TipoUsuario = 2;
            Datos.Imagen = "Hola.jpg";
            ObjUsuario.AgregarUsuario(Datos);
            return RedirectToAction("Index3", "Prueba");
        }

        public ActionResult VerPerfil()
        {
            UsuarioBO Datos = new UsuarioBO();
            Datos.Codigo = int.Parse(Session["Codigo"].ToString());
            return View(ObjUsuario.PerfilUsuario(Datos.Codigo));

        }

        public ActionResult ActualizarPerfil(UsuarioBO Obj)
        {
            ObjUsuario.ActualizarUsuario(Obj);
            return View("IndexEstudiante");
        }
    }
}