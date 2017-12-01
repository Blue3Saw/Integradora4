using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using BO;

namespace DAO
{
    public class InformacionDAO
    {
        ConexionDAO Conexion = new ConexionDAO();
        public int Agregar(InformacionBO obj)
        {
            SqlCommand Cmd = new SqlCommand("insert into Informacion (QuienesSomos,Mision,Vision,ImagenQ,ImagenM,ImagenV) values (@Quines,@Mision,@Vision,@ImgQ,@ImgM,@ImgV)");
            Cmd.Parameters.Add("@Quines", SqlDbType.VarChar).Value = obj.Quienes;
            Cmd.Parameters.Add("@Mision", SqlDbType.VarChar).Value = obj.Mision;
            Cmd.Parameters.Add("@Vision", SqlDbType.VarChar).Value = obj.Vision;
            Cmd.Parameters.Add("@ImgQ", SqlDbType.VarChar).Value = obj.ImagenQ;
            Cmd.Parameters.Add("@ImgM", SqlDbType.VarChar).Value = obj.ImagenM;
            Cmd.Parameters.Add("@ImgV", SqlDbType.VarChar).Value = obj.ImagenV;
            return Conexion.EjecutarComando(Cmd);
        }

        public int Modificar(InformacionBO obj)
        {
            SqlCommand Cmd = new SqlCommand("update Informacion set QuienesSomos = @Quines,Mision = @Mision,Vision = @Vision,ImagenQ = @ImgQ,ImagenM = @ImgM,ImagenV = @ImgV");
            Cmd.Parameters.Add("@Quines", SqlDbType.VarChar).Value = obj.Quienes;
            Cmd.Parameters.Add("@Mision", SqlDbType.VarChar).Value = obj.Mision;
            Cmd.Parameters.Add("@Vision", SqlDbType.VarChar).Value = obj.Vision;
            Cmd.Parameters.Add("@ImgQ", SqlDbType.VarChar).Value = obj.ImagenQ;
            Cmd.Parameters.Add("@ImgM", SqlDbType.VarChar).Value = obj.ImagenM;
            Cmd.Parameters.Add("@ImgV", SqlDbType.VarChar).Value = obj.ImagenV;
            return Conexion.EjecutarComando(Cmd);
        }

        public InformacionBO Datos()
        {
            SqlCommand Comando = new SqlCommand("select * from Informacion");
            SqlDataReader Reader;
            Comando.Connection = Conexion.ConectarBD();
            Conexion.AbrirConexion();
            Reader = Comando.ExecuteReader();
            InformacionBO Informacion = new InformacionBO();
            if(Reader.Read())
            {
                Informacion.Quienes = Reader[0].ToString();
                Informacion.Mision = Reader[1].ToString();
                Informacion.Vision = Reader[2].ToString();
                Informacion.ImagenQ = Reader[3].ToString();
                Informacion.ImagenM = Reader[4].ToString();
                Informacion.ImagenV = Reader[5].ToString();
            }
            Conexion.CerrarConexion();
            return Informacion;
        }

        public int Contador()
        {
            SqlCommand Comando = new SqlCommand("select Count(*) from Informacion");
            SqlDataReader Reader;
            Comando.Connection = Conexion.ConectarBD();
            Conexion.AbrirConexion();
            Reader = Comando.ExecuteReader();
            int Informacion = 0;
            if (Reader.Read())
            {
                Informacion = int.Parse(Reader[0].ToString());
            }
            Conexion.CerrarConexion();
            return Informacion;
        }

        public DataTable TablaInfo()
        {
            string Sentencia = "Select * from Informacion";
            SqlDataAdapter Adap = new SqlDataAdapter(Sentencia, Conexion.ConectarBD());
            DataTable TablaV = new DataTable();
            Adap.Fill(TablaV);
            return TablaV;
        }
    }
}
