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
        public ActionResult AgregarTarea(string agregar,string modificar,string eliminar, string id, string idUsu, string fecha, string horaI, string horaF, string tipo,string descrip, string estatus)
        {
            TareasBO obj = new TareasBO();
            int A = Convert.ToInt32(agregar);
            int M = Convert.ToInt32(modificar);
            int E = Convert.ToInt32(eliminar);

            if(id != "")
            {
                obj.Codigo = Convert.ToInt32(id);
            }
            obj.CodigoEmpleador = Convert.ToInt32(idUsu);
            obj.Fecha = Convert.ToDateTime(fecha);
            obj.HoraInicio = Convert.ToDateTime(horaI);
            obj.HoraFin = Convert.ToDateTime(horaF);
            obj.TipoTarea = Convert.ToInt32(tipo);
            obj.Descripcion = descrip;
            obj.CodigoEstatus = Convert.ToInt32(estatus);
            if(A > 0)
            {
                ObjDAO.AgregarTarea(obj);
                ViewBag.Script = "Agregado";
            }
            else if (M > 0)
            {
                ObjDAO.ActualizarTarea(obj);
            }
            return View("Index");
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
            return PartialView(ObjCla.ListaTipo());
        }

        public ActionResult TodasTareas()
        {
            return View(ObjDAO.TodasTareas());
        }

        public ActionResult TareasAcepUsuario()
        {
            UsuarioBO dato = new UsuarioBO();
            dato.Codigo = 3;
            return View(ObjDAO.TareasAcepUsuario(dato.Codigo));
        }
    }
}