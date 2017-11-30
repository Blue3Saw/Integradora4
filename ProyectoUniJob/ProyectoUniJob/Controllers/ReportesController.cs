using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using BO.Reportes;
using DAO;

namespace ProyectoUniJob.Controllers
{
    public class ReportesController : Controller
    {
        UsuariosDAO ObjDAO = new UsuariosDAO();
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReporteUsuarios()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes/Viewers/"), "UsuarioReport.rpt"));

            rd.SetDataSource(ObjDAO.UsuariosReporte());

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "UsuariosReport.pdf");
        }
    }
}