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
    public class EstatusDAO
    {
        ConexionDAO Conex = new ConexionDAO();
        string sentencia;

        public int AgregarEstatus(object ObjE)
        {
            EstatusBO Dato = (EstatusBO)ObjE;
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO EstatusTarea (Estatus) values (@Estatus)");
            SentenciaSQL.Parameters.Add("@Estatus", SqlDbType.VarChar).Value = Dato.Estatus;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int ActualizarEstatus(object ObjE)
        {
            EstatusBO Dato = (EstatusBO)ObjE;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE EstatusTarea SET Estatus = @Estatus WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.Parameters.Add("@Estatus", SqlDbType.VarChar).Value = Dato.Estatus;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public DataTable VerEstatus()
        {
            sentencia = "SELECT * FROM EstatusTarea";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            return tablavirtual;
        }


        // son las tablas para obtener los mapas


        public DataTable buscardirrecciones()
        {
            sentencia = "select T.Titulo,T.Descripcion,c.Clasificacion,t.Longitud,t.Latitud,t.Codigo from Tareas T,ClasificacionTarea C where t.Tipo=c.Codigo";
            SqlDataAdapter Mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable TablaVirtual = new DataTable();
            Mostar.Fill(TablaVirtual);
            return TablaVirtual;
        }
        public DataTable buscarclasificaciones()
        {
            sentencia = "select *from ClasificacionTarea";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            return tablavirtual;
        }
    }
}
