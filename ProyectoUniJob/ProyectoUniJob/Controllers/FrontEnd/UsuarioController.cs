﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BO;
using DAO;
using System.Data.SqlClient;
using System.IO;

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

        public ActionResult AgregarEmp(string Nombre, string Apellidos, DateTime FechaNac, long Telefono, string Direccion, string Email, string Contraseña)
        {
            UsuarioBO Datos = new UsuarioBO();
            Datos.Nombre = Nombre;
            Datos.Apellidos = Apellidos;
            Datos.FechaNac = FechaNac;
            Datos.Telefono = Telefono;
            Datos.Direccion = Direccion;
            Datos.Email = Email;
            Datos.Contraseña = Contraseña;
            Datos.TipoUsuario = 2;
            Datos.Imagen = "Hola.jpg";
            ObjUsuario.AgregarEmpleador(Datos);

            ObjUsuario.LoginEmpleador(Datos);
            return RedirectToAction("IndexEmpleador", "Usuario");
        }

        public ActionResult VerPerfil()
        {
            return View(ObjUsuario.TablaUsuarios3(int.Parse(Session["Codigo"].ToString())));
        }

        [HttpPost]
        public ActionResult ActualizarPerfil(string ID, string Nombre, string Apellidos, string Correo, string Contraseña, string FechaNac, string Telefono, string direccion, string img, HttpPostedFileBase Imagen)
        {
            UsuarioBO bo = new UsuarioBO();
            if (Imagen != null)
            {
                var filename = Path.GetFileName(Imagen.FileName);
                var path = Path.Combine(Server.MapPath("~/Recursos/FontEnd/images/"), filename);
                Imagen.SaveAs(path);
                bo.Imagen = filename;
            }
            else
            {
                bo.Imagen = img;
            }
            bo.Codigo = int.Parse(ID);
            bo.Nombre = Nombre;
            bo.Apellidos = Apellidos;
            bo.Email = Correo;
            bo.Contraseña = Contraseña;
            bo.Direccion = direccion;
            bo.FechaNac = Convert.ToDateTime(FechaNac);
            bo.Telefono = long.Parse(Telefono);
            ObjUsuario.ActualizarUsuario2(bo);
            IndexEstudiante();
            return View("IndexEstudiante");
        }

        public ActionResult CerrarSesion()
        {
            Session.Remove("Codigo");
            return RedirectToAction("Index", "PrincipalFE");
        }
    }
}