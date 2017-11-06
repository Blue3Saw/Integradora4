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
    public class CalificacionesDAO
    {
        ConexionDAO Conex = new ConexionDAO();
        string sentencia;

        public int AgregarCalificacion(object ObjC)
        {
            CalificacionesBO Dato = (CalificacionesBO)ObjC;
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO Calificaciones (TareaCodigo, CodigoCalificante, CodigoCalificado, Calificacion, Comentario) VALUES (@TareaCodigo, @CodigoCalificante, @CodigoCalificado, @Calificacion, @Comentario)");
            SentenciaSQL.Parameters.Add("@TareaCodigo", SqlDbType.Int).Value = Dato.CodigoTarea;
            SentenciaSQL.Parameters.Add("CodigoCalificante", SqlDbType.Int).Value = Dato.UsCalifica;
            SentenciaSQL.Parameters.Add("CodigoCalificado", SqlDbType.Int).Value = Dato.UsCalificado;
            SentenciaSQL.Parameters.Add("Calificacion", SqlDbType.Int).Value = Dato.Calificacion;
            SentenciaSQL.Parameters.Add("Comentario", SqlDbType.Int).Value = Dato.Comentario;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }
    }
}
