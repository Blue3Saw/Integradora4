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
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO Mensajes (UsEnvia, UsRecibe, FechaHora, Mensaje, Estatus) VALUES (@UsEnvia, @UsRecibe, @FechaHora, @Mensaje, 'Enviado')");
            SentenciaSQL.Parameters.Add("@UsEnvia", SqlDbType.Int).Value = Dato.UsEnvia;
            SentenciaSQL.Parameters.Add("UsRecibe", SqlDbType.Int).Value = Dato.UsRecibe;
            SentenciaSQL.Parameters.Add("FechaHora", SqlDbType.DateTime).Value = Dato.HoraFecha;
            SentenciaSQL.Parameters.Add("Mensaje", SqlDbType.Text).Value = Dato.Mensaje;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }
    }
}
