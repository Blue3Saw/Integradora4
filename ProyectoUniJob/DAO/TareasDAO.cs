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
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO Tareas (UsuarioEmpleador, Fecha, HoraInicio, HoraFin, Tipo, Descripcion, Estatus) VALUES (@Empleador, @Fecha, @HoraInicio, @HoraFin, @Tipo, @Descripcion, @Estatus)");
            SentenciaSQL.Parameters.Add("@Empleador", SqlDbType.Int).Value = Dato.CodigoEmpleador;
            SentenciaSQL.Parameters.Add("@Fecha", SqlDbType.Date).Value = Dato.Fecha;
            SentenciaSQL.Parameters.Add("@HoraInicio", SqlDbType.Time).Value = Dato.HoraInicio;
            SentenciaSQL.Parameters.Add("@HoraFin", SqlDbType.Time).Value = Dato.HoraFin;
            SentenciaSQL.Parameters.Add("@Tipo", SqlDbType.Int).Value = Dato.TipoTarea;
            SentenciaSQL.Parameters.Add("@Descripcion", SqlDbType.Text).Value = Dato.Descripcion;
            SentenciaSQL.Parameters.Add("@Estatus", SqlDbType.Int).Value = Dato.CodigoEstatus;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int ActualizarTarea(object ObjT)
        {
            TareasBO Dato = (TareasBO)ObjT;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Tareas SET Fecha = @Fecha, HoraInicio = @HoraInicio, HoraFin = @HoraFin, Tipo = @Tipo, Descripcion = @Descripcion, Estatus = @Estatus WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.Parameters.Add("@Fecha", SqlDbType.Date).Value = Dato.Fecha;
            SentenciaSQL.Parameters.Add("@HoraInicio", SqlDbType.Time).Value = Dato.HoraInicio;
            SentenciaSQL.Parameters.Add("@HoraFin", SqlDbType.Time).Value = Dato.HoraFin;
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

        public DataTable TareasAcepUsuario(int Codigo)
        {
            UsuarioBO Datos = new UsuarioBO();
            SqlCommand Com = new SqlCommand("SELECT T.Codigo, T.Titulo, T.Descripcion, T.Fecha, T.HoraInicio, T.HoraFinal, (U.Nombre + ' ' + U.Apellidos) AS 'Empleador', CT.Clasificacion FROM Tareas T INNER JOIN Usuarios U ON T.UsuarioEmpleador = U.Codigo INNER JOIN ClasificacionTarea CT ON T.Tipo = CT.Codigo INNER JOIN UsuariosTareas UT ON UT.CodigoEstudiante = U.Codigo WHERE T.Estatus = '1' AND UT.CodigoEstudiante = @Codigo");
            Com.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
            Com.CommandType = CommandType.Text;
            return Conex.EjecutarSentencia(Com).Tables[0];
        }
    }
}
