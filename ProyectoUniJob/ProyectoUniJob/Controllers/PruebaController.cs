using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using DAO;
using System.Data;

namespace ProyectoUniJob.Controllers
{
    public class PruebaController : Controller
    {
        EstatusDAO ObjPersona = new EstatusDAO();
        // GET: Prueba
        string datos = "";
        string ventana = "";
        string link = "";
        string icono = "";

        public ActionResult Index()
        {
            DataTable data = ObjPersona.buscardirrecciones();
            DataTable iconos = ObjPersona.buscarclasificaciones();
            const string quote = "\"";
            int numero = 1;
            List<string> lista = new List<string>();

            //este sirve para obtner una lista de los iconos de los mapas
            foreach (DataRow row in iconos.Rows)
            {
                icono = "var " + row["Clasificacion"].ToString() + " = " + quote + "" + row["Url"].ToString() + "" + quote + "; ";
                lista.Add(icono);
            }




            //este sirve para el contenido de los marker's del mapa
            foreach (DataRow row in data.Rows)
            {
                link = "<a href=" + quote + "/Tareas/TareaSeleccionada?Codigo=" + row["Codigo"].ToString() + "" + quote + "> ver mas</a>";
                ventana = "var contentString = '<div id=" + quote + "content" + quote + ">' + '<div id=" + quote + "siteNotice" + quote + ">' + '</div>' + '<h1 id=" + quote + "firstHeading" + quote + " class=" + quote + "firstHeading" + quote + ">" + row["Titulo"].ToString() + "</h1>' + '<div id=" + quote + "bodyContent" + quote + ">' + '<p>" + row["Descripcion"].ToString() + "<br/></p>' + '<p>" + link + "</p>' + '</div>' + '</div>';";
                datos = ventana + " var infowindow" + numero + " = new google.maps.InfoWindow({content: contentString,maxWidth: 200});var latLng = new google.maps.LatLng(" + row["Latitud"].ToString() + "," + row["Longitud"].ToString() + ");var marker" + numero + " = new google.maps.Marker({position: latLng,icon:" + row["Clasificacion"].ToString() + ",title:'" + row["Titulo"].ToString() + "',map: map}); marker" + numero + ".addListener('click', function() { infowindow" + numero + ".open(map, marker" + numero + ")});" + "\n\r";
                lista.Add(datos);
                numero = numero + 1;
            }

            return View(lista);
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }
    }
}