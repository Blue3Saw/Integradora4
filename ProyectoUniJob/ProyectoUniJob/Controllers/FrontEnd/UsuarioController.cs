using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BO;
using DAO;
using ProyectoUniJob.Controllers;
using System.Data.SqlClient;
using System.IO;

namespace ProyectoUniJob.Controllers.FrontEnd
{
    public class UsuarioController : Controller
    {
        UsuariosDAO ObjUsuario = new UsuariosDAO();
        MensajesDAO ObjMensajes = new MensajesDAO();
        MensajesBO bo = new MensajesBO();
        TareasDAO tareas = new TareasDAO();
        TareasController ObjControl = new TareasController();

        // GET: Usuario
        public ActionResult IndexEmpleador()
        {
            return View();
        }

        public ActionResult IndexEstudiante()
        {
            ViewBag.Tarea = Session["Tarea"];
            if (Session["Codigo"] != null)
            {
                DataTable categorias = tareas.categorias();
                List<string> cate = new List<string>();
                foreach (DataRow item in categorias.Rows)
                {
                    cate.Add(item["Clasificacion"].ToString());
                }

                ViewData["categoria"] = new SelectList(cate);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "PrincipalFE");
            }
            
        }

        public ActionResult Redireccionar()
        {
            return View("Redireccionar");
        }

        public ActionResult AgregarEmp(string Nombre, string Apellidos, DateTime FechaNac, long Telefono, string Direccion, string Email, string Contraseña)
        {
            UsuarioBO Datos = new UsuarioBO();
            Datos.Nombre = Nombre;
            Datos.Apellidos = Apellidos;
            Datos.FechaNac = FechaNac;
            Datos.Telefono = Telefono;
            Datos.Direccion = Direccion;
            Datos.Email = Email;
            Datos.Contraseña = Contraseña;
            Datos.TipoUsuario = 2;
            Datos.Imagen = "Hola.jpg";
            ObjUsuario.AgregarEmpleador(Datos);

            ObjUsuario.LoginEmpleador(Datos);
            return RedirectToAction("IndexEmpleador", "Usuario");
        }

        public ActionResult VerPerfil()
        {
            UsuarioBO ObjBO = new UsuarioBO();
            return View(ObjUsuario.TablaUsuarios3(int.Parse(Session["Codigo"].ToString())));

            //var _fila = Tabla.Rows[0];
            //{
            //    string Contraseña = ObjBO.Desencriptar(_fila.ItemArray[0].ToString());
            //    _fila.ItemArray[7] = Contraseña;
            //}

            ////string Contraseña = ObjBO.Desencriptar(Tabla.Rows[0].ItemArray[7].ToString());
            ////Tabla.Rows[0].ItemArray[7] = Contraseña;
            //return View(Tabla);
        }

        [HttpPost]
        public ActionResult ActualizarPerfil(string ID, string Nombre, string Apellidos, string Correo, string Contraseña, string FechaNac, string Telefono, string direccion, string img, HttpPostedFileBase Imagen)
        {
            UsuarioBO bo = new UsuarioBO();
            if (Imagen != null)
            {
                var filename = Path.GetFileName(Imagen.FileName);
                var path = Path.Combine(Server.MapPath("~/Recursos/FontEnd/images/"), filename);
                Imagen.SaveAs(path);
                bo.Imagen = filename;
            }
            else
            {
                bo.Imagen = img;
            }
            bo.Codigo = int.Parse(ID);
            bo.Nombre = Nombre;
            bo.Apellidos = Apellidos;
            bo.Email = Correo;
            bo.Contraseña = Contraseña;
            bo.Direccion = direccion;
            bo.FechaNac = Convert.ToDateTime(FechaNac);
            bo.Telefono = long.Parse(Telefono);
            int ActPerf = ObjUsuario.ActualizarUsuario2(bo);
            Session["ActPerf"] = ActPerf;
            ViewBag.ActPerf = Session["ActPerf"];
            IndexEstudiante();
            return View("IndexEstudiante");
        }

        public ActionResult CerrarSesion()
        {
            Session.Remove("Codigo");
            return RedirectToAction("Index", "PrincipalFE");
        }

        public ActionResult mesajesusuarios()
        {
            //Session["Codigo"] = 1012;
            return View(ObjMensajes.MOstarMensajes(int.Parse(Session["Codigo"].ToString())));
        }

        [HttpPost]
        public ActionResult enviar(string nombre, string Titulo, string Mensaje, string id)
        {
            bo.HoraFecha = DateTime.Now;
            bo.Mensaje = Mensaje;
            bo.UsRecibe = int.Parse(nombre);
            bo.UsEnvia = int.Parse(Session["Codigo"].ToString());
            bo.idmensaje = int.Parse(id);
            bo.Titulo = Titulo;
            ObjMensajes.actualizarestatus(bo);
            ObjMensajes.AgregarMensaje(bo);
            IndexEstudiante();
            return View("IndexEstudiante");

        }
        public ActionResult enviaradm(string nombre, string Titulo, string Mensaje, string id)
        {
            bo.HoraFecha = DateTime.Now;
            bo.Mensaje = Mensaje;
            bo.UsRecibe = int.Parse(nombre);
            bo.UsEnvia = int.Parse(Session["Codigo"].ToString());
            bo.idmensaje = int.Parse(id);
            bo.Titulo = Titulo;
            ObjMensajes.AgregarMensaje(bo);
            if (Convert.ToInt32(Session["msgadm"].ToString()) == 1)
            {
                IndexEmpleador();
                return View("IndexEmpleador");
            }
            else
            {
                IndexEstudiante();
                return View("IndexEstudiante");
            }

        }

        [HttpPost]
        public ActionResult VariablesTareaBusqueda(string categoria,string Rango,string txtLatitud,string txtLongitud)
        {
            Session["LatitudUsuario"] = txtLatitud;
            Session["longitudUsuario"] = txtLongitud;
            Session["Rango"] = Rango;
            Session["Categoria"] = categoria;

            return Redirect("~/Usuario/IndexEstudiante#parentHorizontalTab2");
        }

        //[HttpPost]
        public ActionResult PefilUsuarioTareas(string Clave)
        {

             int codigo= int.Parse(Clave);

            //este es el datatable que contine la cantidad de estrellas por alumno
            DataTable lol= tareas.Estrellas(codigo);
            //este es el contiene el promedio de la calificacion

            //DataTable prom= tareas.PromedioEstrellas(codigo);
            //double promediocalif = double.Parse(prom.Rows[0][0].ToString());
            double promediocalif = tareas.PromedioEstrellas(codigo);

            ViewData["Promedio"] =Math.Round(promediocalif,1);


            //lista con los datos a mostar
            List<string> ejemplo = new List<string>();
            ejemplo.Add("perro");

            ViewData["Datos"] = ObjUsuario.TablaUsuarios3(codigo);

            ViewData["lol"] = "5";
            ViewData["lista"] = ejemplo;


            //datatable de comentarios
            ViewData["comentarios"] = tareas.comentariodetareas(codigo);

            return View(lol);
        }





        //seccion de metodos para obtener la distancia de las tareas (ojo leer bien, entender o pregubtar antes de modificar

        public DataTable calculardistanciatareas(double logitud, double latitud)
        {
            //variables de la consulta
            var constante = 6378;//radio ecuatorial de la tierra
            double latitudtarea, diferencialongitud;
            double longitudtarea, diferencialatitud;
            double q;
            double final;

            //este es datatable para que quede ordenado de mayor a menor en distancias
            DataTable ordenacion = new DataTable();


            //este es el datatable que tiene las coordenadas de las tareas con estatus 1
            DataTable coordenadas = tareas.cordenadastareas();

            //el que se creara cuando se calculen las distancias
            DataTable distancias = new DataTable();

            //creamos las columnas del datatable
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

                diferencialatitud = radianes(latitudtarea - latitud);
                diferencialongitud = radianes(longitudtarea - logitud);
                var a = Math.Sin(diferencialatitud / 2) * Math.Sin(diferencialatitud / 2) + Math.Sin(diferencialongitud / 2) * Math.Sin(diferencialongitud / 2) * Math.Cos(latitud) * Math.Cos(latitudtarea);
                var c = 2 * Math.Asin(Math.Sqrt(a));

                //distancia final
                final = constante * 2 * Math.Asin(Math.Sqrt(a));
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
                int rows = distancias.Rows.Count;
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


    }
}