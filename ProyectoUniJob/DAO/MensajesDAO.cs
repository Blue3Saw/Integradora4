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
    public class MensajesDAO
    {
        ConexionDAO Conex = new ConexionDAO();
        string sentencia;

        public int AgregarMensaje(object ObjM)
        {
            MensajesBO Dato = (MensajesBO)ObjM;
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO Mensajes (UsEnvia, UsRecibe, FechaHora, Mensaje, Estatus,Titulo) VALUES (@UsEnvia, @UsRecibe, @FechaHora, @Mensaje,1,@Titulo)");
            SentenciaSQL.Parameters.Add("@UsEnvia", SqlDbType.Int).Value = Dato.UsEnvia;
            SentenciaSQL.Parameters.Add("UsRecibe", SqlDbType.Int).Value = Dato.UsRecibe;
            SentenciaSQL.Parameters.Add("FechaHora", SqlDbType.DateTime).Value = Dato.HoraFecha;
            SentenciaSQL.Parameters.Add("Mensaje", SqlDbType.Text).Value = Dato.Mensaje;
            SentenciaSQL.Parameters.Add("Titulo", SqlDbType.Text).Value = Dato.Titulo;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int actualizarestatus(object ObjM)
        {
            MensajesBO Dato = (MensajesBO)ObjM;
            SqlCommand SentenciaSQL = new SqlCommand("update Mensajes set Estatus=0 where id='" + Dato.idmensaje + "'");
            SentenciaSQL.Parameters.Add("id", SqlDbType.Int).Value = Dato.idmensaje;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }


        public DataTable MOstarMensajes(int usuario)
        {
            MensajesBO Datos = new MensajesBO();
            Datos.UsRecibe = usuario;
            sentencia = "select u.Nombre,u.Codigo,m.UsRecibe,m.FechaHora,m.Mensaje,m.Estatus,m.Titulo,m.id  from Usuarios u,Mensajes m where u.Codigo = m.UsEnvia and m.Estatus=1 and m.UsRecibe = '" + Datos.UsRecibe+"'";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            return tablavirtual;
        }
    }
}
