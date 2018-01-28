using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using DAO;
using System.Data;
using System.Device.Location;


namespace ProyectoUniJob.Controllers
{
    public class PruebaController : Controller
    {
        EstatusDAO ObjPersona = new EstatusDAO();
        TareasDAO tareas = new TareasDAO();
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

        
        public ActionResult pruebadistancias()
        {
            double logitud = Convert.ToDouble(Session["longitudUsuario"].ToString());
            double latitud = double.Parse(Session["LatitudUsuario"].ToString());
            double km = double.Parse(Session["Rango"].ToString()); 
            string categoria = Session["Categoria"].ToString();

            DataTable lol = calculardistanciatareas(logitud, latitud,km,categoria);
            //ViewData["coordenada"] = geolocalizacion();
            //ViewData["lol"] = Session["LatitudUsuario"].ToString();

            return View(lol);
        }


        [HttpPost]
        public ActionResult sessioncoordenadas(string txtLatitud, string txtLongitud)
        {
           

            ViewData["lol"] = Session["LatitudUsuario"].ToString();
            ViewData["lol2"] = Session["longitudUsuario"].ToString();

            return View();
        }


        public ActionResult boton()
        {
            return View();
        }

        public DataTable calculardistanciatareas(double logitud,double latitud,double Km, string categoria)
        {
            //variables de la consulta
            var constante = 6378;//radio ecuatorial de la tierra
            double latitudtarea,diferencialongitud;
            double longitudtarea,diferencialatitud;
            double q;
            double final;

            //este es datatable para que quede ordenado de mayor a menor en distancias
            DataTable ordenacion = new DataTable();


            //este es el datatable que tiene las coordenadas de las tareas con estatus 1
            DataTable coordenadas = tareas.cordenadastareas();

            //el que se creara cuando se calculen las distancias
             DataTable distancias = new DataTable();

            //creamos las columnas del datatable
            //distancias.Columns.Add("Codigo");
            //distancias.Columns.Add("latitud");
            //distancias.Columns.Add("logitud");
            //distancias.Columns.Add("distanciaskm");
            distancias.Columns.Add("Codigo");
            distancias.Columns.Add("latitud");
            distancias.Columns.Add("longitud");
            distancias.Columns.Add("distanciaskm");
            distancias.Columns.Add("Titulo");
            distancias.Columns.Add("Descripcion");
            distancias.Columns.Add("Clasificacion");
            distancias.Columns.Add("Nombre");


            foreach (DataRow row in coordenadas.Rows)
            {
                //creamos un datarow para rellanar el nuevo datatable
                DataRow fila = distancias.NewRow();

                //asignamos los datos del anterior datatable
                latitudtarea = double.Parse(row[4].ToString());
                longitudtarea = double.Parse(row[3].ToString());

                //proceso para optener la distancia relativa

                diferencialatitud =radianes(latitudtarea-latitud);
                diferencialongitud =radianes(longitudtarea-logitud);
                var a= Math.Sin(diferencialatitud / 2) * Math.Sin(diferencialatitud / 2) + Math.Sin(diferencialongitud / 2) * Math.Sin(diferencialongitud / 2) * Math.Cos(latitud) * Math.Cos(latitudtarea);
                //var c = 2 * Math.Asin(Math.Sqrt(a));

                //distancia final
                final = constante * 2 * Math.Asin(Math.Sqrt(a));

                if (final <= Km && categoria == row[2].ToString())
                {
                    //creamos la fila del nuevo datatable
                    //fila["Codigo"] = row[0].ToString();
                    //fila["latitud"] = row[1].ToString();
                    //fila["logitud"] = row[2].ToString();
                    fila["Titulo"] = row[0].ToString();
                    fila["Descripcion"] = row[1].ToString();
                    fila["Clasificacion"] = row[2].ToString();
                    fila["longitud"] = row[3].ToString();
                    fila["latitud"] = row[4].ToString();
                    fila["Codigo"] = row[5].ToString();
                    fila["Nombre"] = row[6].ToString() + " " + row[7].ToString();

                    fila["distanciaskm"] = Math.Round(final * 100) / 100;

                    //agregamos la fila
                    distancias.Rows.Add(fila);
                    final = 0;
                }
                int rows= distancias.Rows.Count;
                ViewData["ResultadoBusqueda"] = rows;

            }
            //ordenado los datos
            distancias.DefaultView.Sort = "distanciaskm";
            // se lo pasamos al datatable que creamos de ordenacion

            ordenacion = distancias.DefaultView.ToTable();

            //retornamos el datatable
            return ordenacion;
        }

        public static double radianes(double angle)
        {
            return Math.PI * angle / 180.0;
        }


        public string  geolocalizacion()
        {
            string coordenadas="";
            string la, lo;
            GeoCoordinateWatcher visor;
            visor = new GeoCoordinateWatcher();
            visor.TryStart(false, TimeSpan.FromMilliseconds(100000));
            GeoCoordinate coord = visor.Position.Location;
            if (coord.IsUnknown != true)
            {
                la = coord.Latitude.ToString();
                lo = coord.Longitude.ToString();
                coordenadas = "el resultado es :" + la + "y" + lo;
            }
            else
            {
                coordenadas = "no se encontro la localizacion del equipo";
            }
            return coordenadas;
        }
    }
}