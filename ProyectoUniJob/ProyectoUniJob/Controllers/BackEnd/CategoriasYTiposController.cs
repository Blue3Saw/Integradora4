using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using DAO;

namespace ProyectoUniJob.Controllers.BackEnd
{
    public class CategoriasYTiposController : Controller
    {
        ClasificacionTareaDAO dao = new ClasificacionTareaDAO();
        TipoUsuarioDAO DAO = new TipoUsuarioDAO();
        // GET: CategoriasYTipos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AgregarCategoria()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarCate(string categoria)
        {
            ClasificacionTareaBO bo = new ClasificacionTareaBO();
            bo.Clasificacion = categoria;
            dao.AgregarClasificación(bo);
            return View("AgregarCategoria");
        }
        public ActionResult Agregartipo(string Tipo)
        {
            TipoUsuarioBO bo = new TipoUsuarioBO();
            bo.TipoUsuario = Tipo;
            DAO.AgregarTipoUsuario(bo);
            return View("AgregarCategoria");
        }

        public ActionResult tablacategorias()
        {
            return View(dao.TablaClasificacion());
        }

        public ActionResult tablausuarios()
        {
            return View(DAO.VerTipoUs());
        }

        [HttpPost]
        public ActionResult TablaActualizarCate(string Tipo, string Tiposelect)
        {
            TipoUsuarioBO bo = new TipoUsuarioBO();
            bo.TipoUsuario = Tipo;
            bo.Codigo = int.Parse(Tiposelect);
            DAO.ActualizarTipoUsuario(bo);
            return View("AgregarCategoria");
        }

        [HttpPost]
        public ActionResult actcate(string Tipo, string Tiposelect)
        {
            ClasificacionTareaBO bo = new ClasificacionTareaBO();
            bo.Clasificacion = Tipo;
            bo.Codigo = int.Parse(Tiposelect);
            dao.ActualizarClasificaion(bo);
            return View("AgregarCategoria");
        }


        public ActionResult actualizarcategoria()
        {
            return View(dao.TablaClasificacion());
        }
        public ActionResult TablaActualizarCategoria()
        {
            return View(DAO.buscarTipo());
        }
        public ActionResult Eliminar(string id)
        {
            ClasificacionTareaBO bo = new ClasificacionTareaBO();
            bo.Codigo = int.Parse(id);
            dao.Eliminar(bo);
            AgregarCategoria();
            return View("AgregarCategoria");
        }


    }
}