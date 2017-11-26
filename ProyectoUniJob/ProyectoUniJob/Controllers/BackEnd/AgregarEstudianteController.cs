using System;
using Gma.QrCodeNet.Encoding;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using DAO;
using System.Web.UI;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ProyectoUniJob.Controllers.BackEnd
{
    public class AgregarEstudianteController : Controller
    {
        UsuariosDAO ObjUsuario = new UsuariosDAO();
        
        // GET: AgregarEstudiante
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarUsuario(string agregar, string actualizar, string eliminar, string Nombre, string Apellidos, string cumpleanios, string Email, string Contraseña, string Tipo, string dirreccion, string Telefono,string ID, HttpPostedFileBase Imagen)
        {
            UsuarioBO BO = new UsuarioBO();
            int w = Convert.ToInt32(agregar);
            int r = Convert.ToInt32(actualizar);
            int e = Convert.ToInt32(eliminar);
            //datos BO de Alumno
            BO.Nombre = Nombre;
            if(ID != "")
            {
                BO.Codigo = int.Parse(ID);
            }
            BO.Apellidos = Apellidos;
            BO.Direccion = dirreccion;
            BO.FechaNac = Convert.ToDateTime(cumpleanios);
            BO.Email = Email;
            BO.Contraseña = Contraseña;
            BO.TipoUsuario = int.Parse(Tipo);
            BO.Telefono = long.Parse(Telefono);
            BO.Estatus = "Activo";
            if (Imagen != null)
            {
                var filename = Path.GetFileName(Imagen.FileName);
                var path2 = Path.Combine(Server.MapPath("~/Recursos/BackEnd/img/"), filename);
                Imagen.SaveAs(path2);
                BO.Imagen = filename;
            }
            else
            {
                BO.Imagen = "Ninguna";
            }

            QrEncoder qrencoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrcode = new QrCode();
            string codigo = Nombre + cumpleanios+".png";
            qrencoder.TryEncode(codigo,out qrcode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();

            renderer.WriteToStream(qrcode.Matrix, ImageFormat.Png, ms);
            var imagentemp = new Bitmap(ms);
            var imagenlol = new Bitmap(imagentemp, new Size(new Point(200, 200)));
            var path = Path.Combine(Server.MapPath("~/Recursos/BackEnd/img/"),codigo);
            imagenlol.Save(path);
            BO.QR = codigo;

            if (w > 0)
            {
                ObjUsuario.AgregarUsuario(BO);
                ViewBag.Script = "SE AGREGO CORRECTAMENTE EL USUARIO";
            }
            //else if (r > 0)
            //{
            //    ObjUsuario.ActualizarUsuario(BO);
            //    ViewBag.Script ="SE HA ACTULIZADO LOS DATOS DEL USUARIO CORRECTAMENTE" ;
            //}

            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult datostabla(string Buscar)
        {
            Session["Email"] = Buscar;
            Session["IdEditar"]=ObjUsuario.BuscarId(Buscar);
            return View("Index");
        }
        
        public ActionResult mostartabla()
        {
            return View(ObjUsuario.TablaUsuarios2(Session["Email"].ToString()));
        }

        public ActionResult EditarDatos()
        {
            return View(ObjUsuario.TablaUsuarios3(int.Parse(Session["IdEditar"].ToString())));
        }

        [HttpPost]
        public ActionResult Actualizar(string ID,string Tipo2,string Tipo, string Nombre, string Apellidos, string Correo, string Contraseña, string FechaNac, string Telefono, string dirreccion, string img, HttpPostedFileBase Imagen)
        {
            UsuarioBO bo = new UsuarioBO();
            if (Imagen != null)
            {
                var filename = Path.GetFileName(Imagen.FileName);
                var path = Path.Combine(Server.MapPath("~/Recursos/BackEnd/img/"), filename);
                Imagen.SaveAs(path);
                bo.Imagen = filename;
            }
            else
            {
                bo.Imagen = img;
            }
            if (Tipo != null)
            {
                bo.TipoUsuario = int.Parse(Tipo);
            }
            else
            {
                bo.TipoUsuario = int.Parse(Tipo2);
            }
            bo.Codigo = int.Parse(ID);
            bo.Nombre = Nombre;
            bo.Direccion = dirreccion;
            bo.Apellidos = Apellidos;
            bo.Email = Correo;
            bo.Contraseña = Contraseña;
            bo.FechaNac = Convert.ToDateTime(FechaNac);
            bo.Telefono = long.Parse(Telefono);
            ObjUsuario.ActualizarUsuario2(bo);
            Index();
            return View("Index");
        }

        public ActionResult Eliminar(string id)
        {
            UsuarioBO BO = new UsuarioBO();
            BO.Codigo = int.Parse(id);
            ObjUsuario.EliminarUsuario(BO);

            return View("Index");
        }
    }
}