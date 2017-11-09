using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using DAO;

namespace ProyectoUniJob.Controllers.FrontEnd
{
    public class UsuarioController : Controller
    {
        UsuariosDAO ObjUsuario = new UsuariosDAO();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
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
            Datos.Latitud = 2;
            Datos.Longitud = 2;
            Datos.Imagen = "Hola.jpg";
            ObjUsuario.AgregarUsuario(Datos);
            return RedirectToAction("Index3", "Prueba");
        }
    }
}