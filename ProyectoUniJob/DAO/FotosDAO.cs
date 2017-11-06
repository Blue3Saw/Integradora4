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
    public class FotosDAO
    {
        ConexionDAO Conex = new ConexionDAO();
        string sentencia;

        public int AgregarFoto(object ObjF)
        {
            FotosBO Dato = (FotosBO)ObjF;
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO Fotos (Imagen, TareaID) VALUES (@Imagen, @TareaID)");
            SentenciaSQL.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = Dato.Imagen;
            SentenciaSQL.Parameters.Add("@TareaID", SqlDbType.Int).Value = Dato.CodigoTarea;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int ActualizarFoto(object ObjF)
        {
            FotosBO Dato = (FotosBO)ObjF;
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO Fotos (Imagen, TareaID) VALUES (@Imagen, @TareaID)");
            SentenciaSQL.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = Dato.Imagen;
            SentenciaSQL.Parameters.Add("@TareaID", SqlDbType.Int).Value = Dato.CodigoTarea;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }
    }
}
