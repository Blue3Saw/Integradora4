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
    public class TipoUsuarioDAO
    {
        ConexionDAO Conex = new ConexionDAO();
        string sentencia;

        public int AgregarTipoUsuario(object ObjTU)
        {
            TipoUsuarioBO Dato = (TipoUsuarioBO)ObjTU;
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO TipoUsuario (Tipo) VALUES (@Tipo)");
            SentenciaSQL.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Dato.TipoUsuario;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int ActualizarTipoUsuario(object ObjU)
        {
            TipoUsuarioBO Dato = (TipoUsuarioBO)ObjU;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE TipoUsuario SET Tipo = @Tipo WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Dato.TipoUsuario;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public DataTable VerTipoUs()
        {
            sentencia = "SELECT * FROM TipoUsuario";
            SqlDataAdapter Mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable TablaVirtual = new DataTable();
            Mostar.Fill(TablaVirtual);
            return TablaVirtual;
        }
    }
}
