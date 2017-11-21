using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using BO;
using System.IO;

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
            return View(objUsuario.TablaUsuarios3(int.Parse(Session["Codigo"].ToString())));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult actualizar(string ID, string Nombre, string Apellidos, string Correo, string Contraseña, string FechaNac, string Telefono,string img, HttpPostedFileBase Imagen)
        {
            UsuarioBO bo = new UsuarioBO();
            if (Imagen!=null)
            {
                var filename = Path.GetFileName(Imagen.FileName);
                var path = Path.Combine(Server.MapPath("~/Recursos/BackEnd/img/"), filename);
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
            bo.FechaNac = Convert.ToDateTime(FechaNac);
            bo.Telefono = long.Parse(Telefono);
            objUsuario.ActualizarUsuario2(bo);
            DatosPerfil();
            return View("DatosPerfil");
        }

        public ActionResult eliminarsesion()
        {
            Session.Remove("Codigo");
            return RedirectToAction("Index", "PrincipalFE");
        }
    }
}