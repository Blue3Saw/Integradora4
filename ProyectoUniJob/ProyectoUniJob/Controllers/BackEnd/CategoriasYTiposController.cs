﻿using System;
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
        public ActionResult TablaActualizarCate(string id)
        {
            Session["TIpotabla"] = id;
            return new EmptyResult();
        }
        public ActionResult TablaActualizarCategoria()
        {
            Session["TIpotabla"] = "2";
            return View(DAO.buscarTipo(int.Parse(Session["TIpotabla"].ToString())));
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