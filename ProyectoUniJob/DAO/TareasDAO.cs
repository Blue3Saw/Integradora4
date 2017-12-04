using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class TareasDAO
    {
        ConexionDAO Conex = new ConexionDAO();
        string Sentencia;

        public int AgregarTarea(object ObjT)
        {
            TareasBO Dato = (TareasBO)ObjT;
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO Tareas (UsuarioEmpleador,Titulo, Fecha, HoraInicio, HoraFinal, Tipo, Descripcion, Estatus, Longitud, Latitud, Direccion) VALUES (@Empleador,@Titulo, @Fecha, @HoraInicio, @HoraFin, @Tipo, @Descripcion, @Estatus, @Longitud, @Latitud, @Direccion)");
            SentenciaSQL.Parameters.Add("@Empleador", SqlDbType.Int).Value = Dato.CodigoEmpleador;
            SentenciaSQL.Parameters.Add("@Titulo", SqlDbType.VarChar).Value = Dato.Titulo;
            SentenciaSQL.Parameters.Add("@Fecha", SqlDbType.Date).Value = Dato.Fecha.ToString("yyyy-MM-dd");
            SentenciaSQL.Parameters.Add("@HoraInicio", SqlDbType.Time).Value = Dato.HoraInicio.ToString("HH:mm");
            SentenciaSQL.Parameters.Add("@HoraFin", SqlDbType.Time).Value = Dato.HoraFin.ToString("HH:mm");
            SentenciaSQL.Parameters.Add("@Tipo", SqlDbType.Int).Value = Dato.TipoTarea;
            SentenciaSQL.Parameters.Add("@Descripcion", SqlDbType.Text).Value = Dato.Descripcion;
            SentenciaSQL.Parameters.Add("@Estatus", SqlDbType.Int).Value = 3;
            SentenciaSQL.Parameters.Add("@Longitud", SqlDbType.Float).Value = Dato.Longitud;
            SentenciaSQL.Parameters.Add("@Latitud", SqlDbType.Float).Value = Dato.Latitud;
            SentenciaSQL.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Dato.Direccion;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int ActualizarTarea(object ObjT)
        {
            TareasBO Dato = (TareasBO)ObjT;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Tareas SET Fecha = @Fecha, HoraInicio = @HoraInicio, HoraFin = @HoraFin, Tipo = @Tipo, Descripcion = @Descripcion, Estatus = @Estatus WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.Parameters.Add("@Fecha", SqlDbType.Date).Value = Dato.Fecha;
            SentenciaSQL.Parameters.Add("@HoraInicio", SqlDbType.Time).Value = Dato.HoraInicio.ToString("HH:mm");
            SentenciaSQL.Parameters.Add("@HoraFin", SqlDbType.Time).Value = Dato.HoraFin.ToString("HH:mm");
            SentenciaSQL.Parameters.Add("@Tipo", SqlDbType.Int).Value = Dato.TipoTarea;
            SentenciaSQL.Parameters.Add("@Descripcion", SqlDbType.Text).Value = Dato.Descripcion;
            SentenciaSQL.Parameters.Add("@Estatus", SqlDbType.Int).Value = Dato.CodigoEstatus;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int EliminarTarea(object ObjT)
        {
            TareasBO Dato = (TareasBO)ObjT;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Tareas SET Estatus = @Estatus WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.Parameters.Add("@Estatus", SqlDbType.Int).Value = Dato.CodigoEstatus;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int AceptarTarea(int Codigo)
        {
            TareasBO Dato = new TareasBO();
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Tareas SET Estatus = 5 WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int AceptarTarea2(int CodigoE, int CodigoT)
        {
            TareasBO Dato = new TareasBO();
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO UsuariosTareas (CodigoEstudiante, CodigoTarea, Fecha) VALUES (@CodigoE, @CodigoT, @Fecha)");
            SentenciaSQL.Parameters.Add("@CodigoE", SqlDbType.Int).Value = CodigoE;
            SentenciaSQL.Parameters.Add("@CodigoT", SqlDbType.Int).Value = CodigoT;
            SentenciaSQL.Parameters.Add("@Fecha", SqlDbType.Date).Value = DateTime.Now.ToShortDateString();
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int DejarTarea(int Codigo)
        {
            TareasBO Dato = new TareasBO();
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Tareas SET Estatus = 1 WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int ApRecTarea(object ObjT)
        {
            TareasBO Dato = (TareasBO)ObjT;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Tareas SET Estatus = @Estatus WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.Parameters.Add("@Estatus", SqlDbType.Int).Value = Dato.CodigoEstatus;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public DataTable TodasTareas()
        {
            Sentencia = "SELECT T.Codigo, T.Titulo, T.Descripcion, T.Fecha, T.HoraInicio, T.HoraFinal, (U.Nombre + ' ' + U.Apellidos) AS 'Empleador', CT.Clasificacion FROM Tareas T INNER JOIN Usuarios U ON T.UsuarioEmpleador = U.Codigo INNER JOIN ClasificacionTarea CT ON T.Tipo = CT.Codigo WHERE T.Estatus = 1";
            SqlDataAdapter mostar = new SqlDataAdapter(Sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            return tablavirtual;
        }

        public DataTable TodasTareas2()
        {
            Sentencia = "SELECT T.Codigo, T.Titulo, T.Descripcion, T.Fecha, T.HoraInicio, T.HoraFinal, (U.Nombre + ' ' + U.Apellidos) AS 'Empleador', CT.Clasificacion FROM Tareas T INNER JOIN Usuarios U ON T.UsuarioEmpleador = U.Codigo INNER JOIN ClasificacionTarea CT ON T.Tipo = CT.Codigo WHERE T.Estatus = 3";
            SqlDataAdapter mostar = new SqlDataAdapter(Sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            return tablavirtual;
        }

        public DataTable TareaSeleccionada(int Codigo)
        {
            TareasBO Datos = new TareasBO();
            SqlCommand Com = new SqlCommand("SELECT T.Codigo, T.Titulo, T.Descripcion, T.Direccion, T.Longitud, T.Latitud, T.Fecha, T.HoraInicio, T.HoraFinal, (U.Nombre + ' ' + U.Apellidos) AS 'Empleador', CT.Clasificacion FROM Tareas T INNER JOIN Usuarios U ON T.UsuarioEmpleador = U.Codigo INNER JOIN ClasificacionTarea CT ON T.Tipo = CT.Codigo WHERE T.Codigo = @Codigo");
            Com.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
            Com.CommandType = CommandType.Text;
            return Conex.EjecutarSentencia(Com).Tables[0];
        }

        public DataTable TareasAcepUsuario(int Codigo)
        {
            UsuarioBO Datos = new UsuarioBO();
            SqlCommand Com = new SqlCommand("SELECT T.Codigo, T.Titulo, T.Descripcion, T.Fecha, T.HoraInicio, T.HoraFinal, (U.Nombre + ' ' + U.Apellidos) AS 'Empleador', CT.Clasificacion FROM Tareas T INNER JOIN Usuarios U ON T.UsuarioEmpleador = U.Codigo INNER JOIN ClasificacionTarea CT ON T.Tipo = CT.Codigo INNER JOIN UsuariosTareas UT ON T.Codigo = UT.CodigoTarea WHERE UT.CodigoEstudiante = @Codigo");
            Com.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
            Com.CommandType = CommandType.Text;
            return Conex.EjecutarSentencia(Com).Tables[0];
        }

        public DataTable TareasEmpleador(int Codigo)
        {
            UsuarioBO Datos = new UsuarioBO();
            SqlCommand Com = new SqlCommand("SELECT T.Codigo, T.Titulo, T.Descripcion, T.Direccion, T.Fecha, T.HoraInicio, T.HoraFinal, T.Latitud, T.Longitud, CT.Clasificacion, ET.Estatus FROM Tareas T INNER JOIN EstatusTarea ET ON T.Estatus = ET.Codigo INNER JOIN Usuarios U ON U.Codigo = T.UsuarioEmpleador INNER JOIN ClasificacionTarea CT ON CT.Codigo = T.Tipo WHERE T.UsuarioEmpleador = @Codigo");
            Com.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
            Com.CommandType = CommandType.Text;
            return Conex.EjecutarSentencia(Com).Tables[0];
        }

        public TareasBO DatosTareaAceptar(int Codigo)
        {
            TareasBO Datos = new TareasBO();
            SqlCommand Com = new SqlCommand("SELECT * FROM Tareas t WHERE t.Codigo = @Codigo");
            Com.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
            Com.CommandType = CommandType.Text;
            DataTable Tabla = new DataTable();
            Tabla = Conex.EjecutarSentencia(Com).Tables[0];

            var _fila = Tabla.Rows[0];
            {
                Datos.Codigo = int.Parse(_fila.ItemArray[0].ToString());
                Datos.CodigoEmpleador = int.Parse(_fila.ItemArray[1].ToString());
                Datos.Titulo = _fila.ItemArray[2].ToString();
                Datos.Fecha= Convert.ToDateTime(_fila.ItemArray[3].ToString());
                Datos.HoraInicio = DateTime.Parse(_fila.ItemArray[4].ToString());
                Datos.HoraFin = DateTime.Parse(_fila.ItemArray[5].ToString());
                Datos.TipoTarea = int.Parse(_fila.ItemArray[6].ToString());
                Datos.Descripcion = _fila.ItemArray[7].ToString();
                Datos.CodigoEstatus= int.Parse(_fila.ItemArray[8].ToString());
            }
            return Datos;
        }


        public DataTable TablaTareas2(int id)
        {
            TareasBO Datos = new TareasBO();
            Datos.Codigo = id;
            string sentencia = "select t.Codigo,u.Nombre,u.Imagen,u.Apellidos,t.Titulo,t.Fecha,t.HoraInicio,t.HoraFinal,c.Clasificacion,t.Descripcion,t.Longitud,t.Latitud,t.Direccion from Tareas t,Usuarios U, ClasificacionTarea c where u.Codigo = t.UsuarioEmpleador and c.Codigo = t.Tipo and t.Codigo = '" + Datos.Codigo+"'";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            return tablavirtual;
        }

        public DataTable TareasReporte()
        {
            Sentencia = "SELECT T.Codigo, T.Titulo, T.Direccion, CT.Clasificacion, T.Fecha, (U.Nombre + ' ' + U.Apellidos) AS 'Empleador', E.Estatus FROM Tareas T INNER JOIN ClasificacionTarea CT ON T.Estatus = CT.Codigo INNER JOIN Usuarios U ON T.UsuarioEmpleador = U.Codigo INNER JOIN EstatusTarea E ON T.Estatus = E.Codigo";
            SqlDataAdapter mostar = new SqlDataAdapter(Sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            return tablavirtual;
        }
    }
}
