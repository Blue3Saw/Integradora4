using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using BO;

namespace ProyectoUniJob.Controllers.FrontEnd
{
    public class TareasController : Controller
    {
        TareasDAO ObjDAO = new TareasDAO();

        // GET: Tareas
        public ActionResult Index()
        {      
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarTarea(string agregar, string modificar, string eliminar, string IdTarea, string NombreUsu, string Titulo, string Direccion,
            string Latitud, string Longitud, string FechaTarea, string HoraInicioTarea, string HoraFinTarea, string cmbClas, string Descripcion, string inputLabel)
        {
            TareasBO obj = new TareasBO();
            int A = Convert.ToInt32(agregar);
            int M = Convert.ToInt32(modificar);
            int E = Convert.ToInt32(eliminar);

            if (IdTarea != "")
            {
                obj.Codigo = Convert.ToInt32(IdTarea);
            }

            obj.CodigoEmpleador = (int)Session["Codigo"]; //Convert.ToInt32(NombreUsu);

            obj.CodigoEmpleador = int.Parse(Session["Codigo"].ToString()); //Convert.ToInt32(NombreUsu);

            obj.Titulo = Titulo;
            obj.Direccion = Direccion;
            obj.Latitud = float.Parse(Latitud);
            obj.Longitud = float.Parse(Longitud);
            obj.Fecha = DateTime.Parse(FechaTarea);
            obj.HoraInicio = DateTime.Parse(HoraInicioTarea);
            obj.HoraFin = DateTime.Parse(HoraFinTarea);
            obj.TipoTarea = Convert.ToInt32(cmbClas);
            obj.Descripcion = Descripcion;
            obj.CodigoEstatus = Convert.ToInt32(inputLabel);
            if (A > 0)
            {
                ObjDAO.AgregarTarea(obj);
                ViewBag.Script = "Agregado";
            }
            else if (M > 0)
            {
                ObjDAO.ActualizarTarea(obj);
            }
            return Redirect("/Usuario/IndexEmpleador#parentHorizontalTab2");
        }
        public ActionResult EliminarTarea(string id)
        {
            TareasBO objBO = new TareasBO();
            objBO.Codigo = int.Parse(id);
            ObjDAO.EliminarTarea(objBO);
            return View("Index");
        }
        public ActionResult ListarTipoTarea()
        {
            ClasificacionTareaDAO ObjCla = new ClasificacionTareaDAO();
            var Tipo = new ClasificacionTareaBO();
            Tipo.TipoTarea = ObjCla.ListaTipo();
            return PartialView(Tipo.TipoTarea);
        }

        public ActionResult TodasTareas()
        {
            return View(ObjDAO.TodasTareas());
        }

        public ActionResult TareasAcepUsuario()
        {
            UsuarioBO dato = new UsuarioBO();
            dato.Codigo = int.Parse(Session["Codigo"].ToString());
            return View(ObjDAO.TareasAcepUsuario(dato.Codigo));
        }

        public ActionResult TareaAceptSeleccionada(string Codigo)
        {
            int Clave = int.Parse(Codigo);
            return View(ObjDAO.TareaSeleccionada(Clave));
        }

        public ActionResult TareaSeleccionada(string Codigo)
        {
            int Clave = int.Parse(Codigo);
            return View(ObjDAO.TareaSeleccionada(Clave));
        }
        [ChildActionOnly]
        public ActionResult VistaTarea()
        {
            
            return PartialView("VistaTarea");
        }

        public ActionResult HacerTarea(string Codigo)
        {
            int Estudiante = int.Parse(Session["Codigo"].ToString());
            int Clave = int.Parse(Codigo);
            ObjDAO.AceptarTarea(Clave);
            ObjDAO.AceptarTarea2(Estudiante, Clave);
            Session["Tarea"] = Codigo;
            return RedirectToAction("IndexEstudiante", "Usuario");
        }
    }
}