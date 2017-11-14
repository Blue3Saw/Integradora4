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
    public class ClasificacionTareaDAO
    {
        ConexionDAO Conex = new ConexionDAO();
        string sentencia;

        public int AgregarClasificación(object ObjC)
        {
            ClasificacionTareaBO Dato = (ClasificacionTareaBO)ObjC;
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO ClasificacionTarea (Clasificacion) VALUES (@Clasificacion)");
            SentenciaSQL.Parameters.Add("@Clasificacion", SqlDbType.VarChar).Value = Dato.Clasificacion;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int ActualizarClasificaion(object ObjC)
        {
            ClasificacionTareaBO Dato = (ClasificacionTareaBO)ObjC;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE TipoUsuario SET Clasificacion = @Clasificacion WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.Parameters.Add("@Clasificacion", SqlDbType.VarChar).Value = Dato.Clasificacion;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public List<ClasificacionTareaBO>ListaTipo()
        {
            string Sentencia = ("select Codigo,Clasificacion from ClasificacionTarea");
            var Result = Conex.EjecutarSentencia(Sentencia);
            List<ClasificacionTareaBO> ListaT = new List<ClasificacionTareaBO>();
            foreach(DataRow Tipo in Result.Tables[0].Rows)
            {
                var TipoBO = new ClasificacionTareaBO();
                TipoBO.Codigo = Convert.ToInt32(Tipo[0].ToString());
                TipoBO.Clasificacion = Tipo[1].ToString();
                ListaT.Add(TipoBO);
            }
            return ListaT;

        }
    }
}
