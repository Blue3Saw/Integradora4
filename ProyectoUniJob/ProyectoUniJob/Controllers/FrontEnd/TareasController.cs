using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO;
using BO;
using System.Net.Mail;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ProyectoUniJob.Controllers.FrontEnd
{
    public class TareasController : Controller
    {        
        TareasDAO ObjDAO = new TareasDAO();
        FotosDAO DAOFoto = new FotosDAO();        
        // GET: Tareas
        public ActionResult Index()
        {      
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarTarea(string agregar, string modificar, string eliminar, string IdTarea, string NombreUsu, string Titulo, string Direccion,
            string Latitud, string Longitud, string FechaTarea, string HoraInicioTarea, string HoraFinTarea, string cmbClas, string Descripcion, string inputLabel,
            string CantPersonas, IEnumerable<HttpPostedFileBase> Imagen)
        {
            TareasBO obj = new TareasBO();
            int A = Convert.ToInt32(agregar);
            int M = Convert.ToInt32(modificar);
            int E = Convert.ToInt32(eliminar);

            if (IdTarea != "")
            {
                obj.Codigo = Convert.ToInt32(IdTarea);
            }

            //obj.CodigoEmpleador = 3;// (int)Session["Codigo"]; //Convert.ToInt32(NombreUsu);

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
            obj.CantPersonas = Convert.ToInt32(CantPersonas);
           
            if (A > 0)
            {               
                obj.Codigo = ObjDAO.AgregarTarea(obj);
                AgregarImagenTarea(Imagen, obj.Codigo);
                ViewBag.Script = "Agregado";
            }
            else if (M > 0)
            {
                ObjDAO.ActualizarTarea(obj);
            }
            return Redirect("/Usuario/IndexEmpleador#parentHorizontalTab2");
        }
        public void AgregarImagenTarea(IEnumerable<HttpPostedFileBase> Imagen, int IdTarea)
        {
            FotosBO FotBO = new FotosBO();
            FotosDAO DAOFotos = new FotosDAO();
            FotBO.CodigoTarea = IdTarea;
            if (Imagen != null)
            {
                foreach (var item in Imagen)
                {
                    var filename = Path.GetFileName(item.FileName);
                    var path2 = Path.Combine(Server.MapPath("~/Recursos/FontEnd/images/"), filename);
                    item.SaveAs(path2);
                    FotBO.Imagen = filename;
                    DAOFotos.AgregarFoto(FotBO);
                }
            }
            else
            {
                FotBO.Imagen = "Ninguna";
            }           
        }

        public ActionResult Upload(IEnumerable<HttpPostedFileBase> Imagen)
        {
            return new EmptyResult();
        }

        public ActionResult BuscarTarea(string Codigo)
        {
            int Clave = int.Parse(Codigo);
            return View(ObjDAO.BuscarTarea(Clave));
        }

        public ActionResult ActualizarTarea()
        {
            return View();
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

        public ActionResult TodasTareasEmpleador(int filtro)
        {
            int Codigo = int.Parse(Session["Codigo"].ToString());
            int f = filtro;
            return View(ObjDAO.TodasTareasEmpleador(Codigo,f));
        }

        public ActionResult Filtro(string Filtro)
        {
            int Codigo = int.Parse(Session["Codigo"].ToString());

            if (Filtro == "2")
            {
                ViewBag.Aprobadas = 2;
                return PartialView(ObjDAO.TareasAprobadas(Codigo));
                //return View(ObjDAO.TareasAprobadas(Codigo));
            }
            else
            {
                ViewBag.Aprobadas = 3;
                return PartialView(model: "3");
                //return View(ObjDAO.TareasRechazadas(Codigo));
                int filtro = 0;
                int Cod = int.Parse(Session["Codigo"].ToString());
                if (Session["Filtro"].ToString() == null)
                {
                    filtro = 0;
                }
                else
                {
                    filtro = int.Parse(Session["Filtro"].ToString());
                }
                return View(ObjDAO.TodasTareasEmpleador(Cod, filtro));
            }
        }

        [HttpPost]
        public ActionResult FiltroTareas(string Filtro)
        {
            int entrada = int.Parse(Filtro);
            Session["Filtro"] = entrada;
            return Redirect("~/Usuario/IndexEmpleador");
        }
        public ActionResult FiltroTareasView()
        {
            return View("FiltroTareas");
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
        public ActionResult FinalizarTarea()
        {
            
            return Redirect("/Usuario/IndexEmpleador#parentHorizontalTab5");
        }
        public ActionResult AgregarCalif(string calif, string comentario, int tarea, int empleador)
        {
            CalificacionesBO OBO = new CalificacionesBO();
            CalificacionesDAO obj = new CalificacionesDAO();
            int Tarea = tarea;
            
            OBO.CodigoTarea = Tarea;
            OBO.UsCalifica = int.Parse(Session["codigo"].ToString());
            OBO.UsCalificado =empleador;
            OBO.Calificacion = int.Parse(calif);
            OBO.Comentario = comentario;
            obj.AgregarCalificacion(OBO);
            //Session["Tarea"] = codigo;
            return RedirectToAction("IndexEstudiante", "Usuario");
        }
        [HttpGet]
        public ActionResult EnviarCorreoView()
        {
            return View("EnviarCorreo");
        }

        [HttpPost]
        public ActionResult EnviarCorreo()
        {             
            DAO.UsuariosDAO User = new UsuariosDAO();           
            UsuarioBO Usuario = User.PerfilUsuario(int.Parse(Session["codigo"].ToString()));
            string CorreoRemitente = "collegeJobSGM@gmail.com";             
            string CorreoDestinatario = Usuario.Email; 
            MailMessage Correo = new MailMessage();
            Correo.To.Add(new MailAddress(CorreoDestinatario));
            Correo.From = new MailAddress(CorreoRemitente);
            Correo.Subject = "Mensajes de prueba..";
            Correo.Body = "Prueba 1 <a href='http://localhost:59538/Tareas/VistaCAlif'><img src='http://noeliareginelli.com/wp-content/uploads/2017/10/boton-clic-aqui.png' width='120px'/></a>";
            Correo.IsBodyHtml = true;
            Correo.Priority = MailPriority.Normal;
            SmtpClient Cliente = new SmtpClient();
            Cliente.Host = "smtp.gmail.com";
            Cliente.Port = 587;
            Cliente.EnableSsl = true;
            Cliente.Credentials = new NetworkCredential("collegeJobSGM@gmail.com", "SGM123456");
            try
            {
                Cliente.Send(Correo);
                return Redirect("/Usuario/IndexEmpleador#parentHorizontalTab5");
            }
            catch 
            {
                return Content("Error");
            }
        }
        public ActionResult VistaCAlif()
        {
            return View();
        }
        //metodos para la vista de ver perfil usuario por parte del empleador        
    }
}