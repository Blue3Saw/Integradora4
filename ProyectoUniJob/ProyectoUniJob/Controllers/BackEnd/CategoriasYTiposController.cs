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
            int CodAgreCat = dao.AgregarClasificación(bo);
            Session["CodAgreCat"] = CodAgreCat;
            ViewBag.CodAgreCat = Session["CodAgreCat"];
            return View("AgregarCategoria");
        }
        public ActionResult Agregartipo(string Tipo)
        {
            TipoUsuarioBO bo = new TipoUsuarioBO();
            bo.TipoUsuario = Tipo;
            int CodAgreTip = DAO.AgregarTipoUsuario(bo);
            Session["CodAgreTip"] = CodAgreTip;
            ViewBag.CodAgreTip = Session["CodAgreTip"];
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
            int CodActTip = DAO.ActualizarTipoUsuario(bo);
            Session["CodActTip"] = CodActTip;
            ViewBag.CodActTip = Session["CodActTip"];
            return View("AgregarCategoria");
        }

        [HttpPost]
        public ActionResult actcate(string Tipo, string Tiposelect)
        {
            ClasificacionTareaBO bo = new ClasificacionTareaBO();
            bo.Clasificacion = Tipo;
            bo.Codigo = int.Parse(Tiposelect);
            int CodActClas = dao.ActualizarClasificaion(bo);
            Session["CodActClas"] = CodActClas;
            ViewBag.CodActClas = Session["CodActClas"];
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
            int CodElClas = dao.Eliminar(bo);
            Session["CodElClas"] = CodElClas;
            ViewBag.CodElClas = Session["CodElClas"];
            AgregarCategoria();
            return View("AgregarCategoria");
        }


    }
}