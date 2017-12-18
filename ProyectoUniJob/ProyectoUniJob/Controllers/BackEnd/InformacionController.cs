using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BO;
using DAO;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ProyectoUniJob.Controllers.BackEnd
{
    public class InformacionController : Controller
    {
        InformacionDAO ObjDAO = new InformacionDAO();
        UsuariosDAO usuarios = new UsuariosDAO();
        // GET: Informacion
        public ActionResult Index()
        {
            return View(ObjDAO.Datos());
        }
        public ActionResult AgregarInformacion(string Quienes,string Mision,string Vision, HttpPostedFileBase ImgQ,
           HttpPostedFileBase ImgM, HttpPostedFileBase ImgV, string IQ, string IV, string IM)
        {
            InformacionBO Obj = new InformacionBO();

            Obj.Quienes = Quienes;
            Obj.Mision = Mision;
            Obj.Vision = Vision;
            if (ImgQ != null)
            {              
                Obj.ImagenQ = GuardarImagen(ImgQ);
            }
            else
            {
                Obj.ImagenQ = IQ;
            }
            if (ImgM != null)
            {               
                Obj.ImagenM = GuardarImagen(ImgM);
            }
            else
            {
                Obj.ImagenM = IM;
            }
            if (ImgV != null)
            {
                Obj.ImagenV = GuardarImagen(ImgV);
            }
            else
            {
                Obj.ImagenV = "Ninguna";
            }                   
            if (ObjDAO.Contador() == 0)
            {
                ObjDAO.Agregar(Obj);
            }
            else if(ObjDAO.Contador() > 0)
            {
                ObjDAO.Modificar(Obj);
            }                            
            return RedirectToAction("Index");
        }
        public ActionResult TablaInformacionPag()
        {
            return View(ObjDAO.TablaInfo());
        }           
        public string GuardarImagen(HttpPostedFileBase Variable)
        {
            var filename = Path.GetFileName(Variable.FileName);
            var path2 = Path.Combine(Server.MapPath("~/Recursos/BackEnd/img/"), filename);
            Variable.SaveAs(path2);
            return filename;
        }


        public ActionResult PaginaPrincipal()
        {
            ViewData["Empleador"] = usuarios.Empleadores();
            ViewData["Estudiante"] = usuarios.Estudiantes();
            ViewData["Mensajes"] = usuarios.MensajesSinleer(int.Parse(Session["Codigo"].ToString()));
            ViewData["TareasEjecucion"] = usuarios.tareasEnjecucion();
            ViewData["TareasPorAceptar"] = usuarios.tareasverificar();
            ViewData["TareasRechazadas"] = usuarios.tareasRechazadas();
            return View();
        }

    }

}