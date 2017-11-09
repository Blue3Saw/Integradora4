﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using DAO;
using System.Web.UI;

namespace ProyectoUniJob.Controllers.BackEnd
{
    public class AgregarEstudianteController : Controller
    {
        UsuariosDAO ObjUsuario = new UsuariosDAO();
        
        // GET: AgregarEstudiante
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarUsuario(string agregar, string actualizar, string eliminar, string Nombre, string Apellidos, string cumpleanios, string Email, string Contraseña, string Imagen, string Tipo, string dirreccion, string Telefono,string ID)
        {
            UsuarioBO BO = new UsuarioBO();
            int w = Convert.ToInt32(agregar);
            int r = Convert.ToInt32(actualizar);
            int e = Convert.ToInt32(eliminar);
            //datos BO de Alumno
            BO.Nombre = Nombre;
            BO.Codigo = int.Parse(ID);
            BO.Apellidos = Apellidos;
            BO.FechaNac = Convert.ToDateTime(cumpleanios);
            BO.Email = Email;
            BO.Contraseña = Contraseña;
            BO.Imagen = Imagen;
            BO.TipoUsuario = int.Parse(Tipo);
            BO.Telefono = int.Parse(Telefono);
            BO.Estatus = "Activo";

            if (w > 0)
            {
                ObjUsuario.AgregarUsuario(BO);
                ViewBag.Script = "SE AGREGO CORRECTAMENTE EL USUARIO";
            }
            else if (r > 0)
            {
                ObjUsuario.ActualizarUsuario(BO);
                ViewBag.Script ="SE HA ACTULIZADO LOS DATOS DEL USUARIO CORRECTAMENTE" ;
            }
            else if (e > 0)
            {
                ObjUsuario.EliminarUsuario(BO);
                ViewBag.Script = "SE HA ELIMINADO EL USUARIO";
            }

            return View("Index");
        }
        
        public ActionResult actulizarDatos_Admin()
        {
            return View("Index");
        }
    }
}