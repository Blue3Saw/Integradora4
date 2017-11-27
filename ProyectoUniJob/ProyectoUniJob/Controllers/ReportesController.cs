using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using Microsoft.Reporting.WebForms;
using BO;
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

        /*public ActionResult ReporteUsuarios()
        {
            #region Datos dummy
            var result = ObjDAO.UsuariosReporte();
            List<UsuarioBO> DetUsuario = new List<UsuarioBO>();
            foreach (DataRow detalles in result.Rows)
            {
                var DetUsuarioBO = new UsuarioBO();
                DetUsuarioBO.Codigo = int.Parse(detalles[0].ToString());
                DetUsuarioBO.Nombre = detalles[1].ToString();
                DetUsuarioBO.Apellidos = detalles[2].ToString();
                DetUsuarioBO.FechaNac = DateTime.Parse(detalles[3].ToString());
                DetUsuarioBO.Direccion = detalles[4].ToString();
                DetUsuarioBO.Telefono = long.Parse(detalles[5].ToString());
                DetUsuarioBO.Email = detalles[6].ToString();
                DetUsuarioBO.Add(DetUsuarioBO);
            }
            #endregion Datos dummy
            string DirRepor = "~/Reportes/Reportes/";
            string urlArchivo = string.Format("{0}.{1}", "DetalleVentaRepor", "rdlc");
            string FullReport = string.Format("{0}{1}", this.HttpContext.Server.MapPath(DirRepor), urlArchivo);
            ReportViewer reporte = new ReportViewer();
            reporte.Reset();
            reporte.LocalReport.ReportPath = FullReport;
            ReportDataSource DatosDS = new ReportDataSource("DSDetalleVenta", DetVenta);
            reporte.LocalReport.DataSources.Add(DatosDS);
            reporte.LocalReport.Refresh();
            byte[] file = reporte.LocalReport.Render("PDf");

            return File(new MemoryStream(file).ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, string.Format("{0}{1}", "Reporte_DetalleVenta.", "PDF"));
        }*/
    }
}