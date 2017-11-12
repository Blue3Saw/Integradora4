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
        public ActionResult IndexEmpleador()
        {
            return View("IndexEmpleador");
        }

        public ActionResult IndexEstudiante()
        {
            return View("IndexEstudiante");
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

        public ActionResult VerPerfil()
        {
            UsuarioBO Datos = new UsuarioBO();
            var _fila = ObjUsuario.VerPerfil(2).Tables[0].Rows[0];
            {
                Datos.Codigo = int.Parse(_fila.ItemArray[0].ToString());
                Datos.Nombre = _fila.ItemArray[1].ToString();
                Datos.Apellidos = _fila.ItemArray[2].ToString();
                Datos.FechaNac = DateTime.Parse(_fila.ItemArray[4].ToString());
                Datos.Telefono = long.Parse(_fila.ItemArray[5].ToString());
                Datos.Email = _fila.ItemArray[6].ToString();
                Datos.Contraseña = _fila.ItemArray[7].ToString();
                Datos.Imagen = _fila.ItemArray[8].ToString();
            }
            
            return View(ObjUsuario.VerPerfil(2));
        }

        public ActionResult ActualizarPerfil(UsuarioBO Obj)
        {
            ObjUsuario.ActualizarUsuario(Obj);
            return View("IndexEstudiante");
        }
        
    }
}