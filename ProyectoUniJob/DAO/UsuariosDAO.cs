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
    public class UsuariosDAO
    {
        ConexionDAO Conex = new ConexionDAO();
        string sentencia;

        public int AgregarUsuario(object ObjU)
        {
            UsuarioBO Dato = (UsuarioBO)ObjU;
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO Usuarios (Nombre, Apellidos, Ubicacion, FechaNac, Telefono, Email, Contraseña, TipoUs, Estatus, Imagen) VALUES (@Nombre, @Apellidos, Geography::Point(@Latitud, @Longitud, 4326), @FechaNac, @Telefono, @Email, @Contraseña, @TipoUs, 'En revisión', @Imagen)");
            SentenciaSQL.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Dato.Nombre;
            SentenciaSQL.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = Dato.Apellidos;
            SentenciaSQL.Parameters.Add("@Longitud", SqlDbType.Float).Value = Dato.Longitud;
            SentenciaSQL.Parameters.Add("@Latitud", SqlDbType.Float).Value = Dato.Latitud;
            SentenciaSQL.Parameters.Add("@FechaNac", SqlDbType.Date).Value = Dato.FechaNac;
            SentenciaSQL.Parameters.Add("@Telefono", SqlDbType.BigInt).Value = Dato.Telefono;
            SentenciaSQL.Parameters.Add("@Email", SqlDbType.VarChar).Value = Dato.Email;
            SentenciaSQL.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Dato.Contraseña;
            SentenciaSQL.Parameters.Add("@TipoUs", SqlDbType.Int).Value = Dato.TipoUsuario;
            SentenciaSQL.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = Dato.Imagen;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int ActualizarUsuario(object ObjU)
        {
            UsuarioBO Dato = (UsuarioBO)ObjU;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Usuarios SET Nombre = @Nombre, Apellidos = @Apellidos, Ubicacion = Geography::Point(@Latitud, @Longitud, 4326), FechaNac = @FechaNac, Telefono = @Telefono, Email = @Email, Contraseña = @Contraseña, TipoUs = @TipoUs, Estatus = 'En revisión', Imagen = @Imagen WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Dato.Nombre;
            SentenciaSQL.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = Dato.Apellidos;
            SentenciaSQL.Parameters.Add("@Longitud", SqlDbType.Float).Value = Dato.Longitud;
            SentenciaSQL.Parameters.Add("@Latitud", SqlDbType.Float).Value = Dato.Latitud;
            SentenciaSQL.Parameters.Add("@FechaNac", SqlDbType.Date).Value = Dato.FechaNac;
            SentenciaSQL.Parameters.Add("@Telefono", SqlDbType.BigInt).Value = Dato.Telefono;
            SentenciaSQL.Parameters.Add("@Email", SqlDbType.VarChar).Value = Dato.Email;
            SentenciaSQL.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Dato.Contraseña;
            SentenciaSQL.Parameters.Add("@TipoUs", SqlDbType.Int).Value = Dato.TipoUsuario;
            SentenciaSQL.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = Dato.Imagen;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int EliminarUsuario(object ObjU)
        {
            UsuarioBO Dato = (UsuarioBO)ObjU;
            SqlCommand SentenciaSQL = new SqlCommand("Delete from Usuarios WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int AceptarUsuario(object ObjU)
        {
            UsuarioBO Dato = (UsuarioBO)ObjU;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Usuarios SET Estatus = 'Activo' WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int RechazarUsuario(object ObjU)
        {
            UsuarioBO Dato = (UsuarioBO)ObjU;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Usuarios SET Estatus = 'Rechazado' WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        //Logins para usuarios
        public int LoginAdministrador(object ObjU)
        {
            UsuarioBO Datos = (UsuarioBO)ObjU;
            SqlCommand Com = new SqlCommand("SELECT * FROM Usuarios WHERE Email = @Email AND Contraseña = @Contraseña AND TipoUs = 1");
            Com.Parameters.Add("@Email", SqlDbType.VarChar).Value = Datos.Email;
            Com.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Datos.Contraseña;
            Com.CommandType = CommandType.Text;
            return Conex.EjecutarComando(Com);
        }

        public int LoginEstudiante(object ObjU)
        {
            UsuarioBO Datos = (UsuarioBO)ObjU;
            SqlCommand Com = new SqlCommand("SELECT * FROM Usuarios WHERE Email = @Email AND Contraseña = @Contraseña AND TipoUs = 3");
            Com.Parameters.Add("@Email", SqlDbType.VarChar).Value = Datos.Email;
            Com.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Datos.Contraseña;
            Com.CommandType = CommandType.Text;
            return Conex.EjecutarComando(Com);
        }

        public int LoginEmpleador(object ObjU)
        {
            UsuarioBO Datos = (UsuarioBO)ObjU;
            SqlCommand Com = new SqlCommand("SELECT * FROM Usuarios WHERE Email = @Email AND Contraseña = @Contraseña AND TipoUs = 2");
            Com.Parameters.Add("@Email", SqlDbType.VarChar).Value = Datos.Email;
            Com.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Datos.Contraseña;
            Com.CommandType = CommandType.Text;
            return Conex.EjecutarComando(Com);
        }

        //------------------------------------------------------------------------------------------------------
        
        public DataTable TablaUsuarios()
        {
            sentencia = "SELECT * FROM Usuarios";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            return tablavirtual;
        }
        public DataTable TablaUsuarios2(string email)
        {
            UsuarioBO Datos = new UsuarioBO();
            Datos.Email = email;
            sentencia = "SELECT * FROM Usuarios where Email='"+Datos.Email+"'";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            return tablavirtual;
        }
        public int BuscarId(string email)
        {
            UsuarioBO Datos = new UsuarioBO();
            Datos.Email = email;
            sentencia = "SELECT Codigo FROM Usuarios where Email='" + Datos.Email + "'";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            DataRow lol = tablavirtual.Rows[0];
            int valor = int.Parse(lol["Codigo"].ToString());

            return valor;
        }

        public UsuarioBO PerfilUsuario(int Codigo)
        {
            UsuarioBO Datos = new UsuarioBO();
            SqlCommand Com = new SqlCommand("SELECT * FROM Usuarios U WHERE U.Codigo = @Codigo");
            Com.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
            Com.CommandType = CommandType.Text;
            DataTable Tabla = new DataTable();
            Tabla = Conex.EjecutarSentencia(Com).Tables[0];

            var _fila = Tabla.Rows[0];
            {
                Datos.Nombre = _fila.ItemArray[1].ToString();
                Datos.Apellidos = _fila.ItemArray[2].ToString();
                Datos.FechaNac = DateTime.Parse(_fila.ItemArray[4].ToString());
                Datos.Telefono = long.Parse(_fila.ItemArray[5].ToString());
                Datos.Email = _fila.ItemArray[6].ToString();
            }
            return Datos;
        }


        public UsuarioBO PerfilUsuario2(int Codigo)
        {
            UsuarioBO Datos = new UsuarioBO();
            SqlCommand Com = new SqlCommand("SELECT * FROM Usuarios U WHERE U.Codigo = @Codigo");
            Com.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
            Com.CommandType = CommandType.Text;
            DataTable Tabla = new DataTable();
            Tabla = Conex.EjecutarSentencia(Com).Tables[0];

            var _fila = Tabla.Rows[0];
            {
                Datos.Codigo = int.Parse(_fila.ItemArray[0].ToString());
                Datos.Nombre = _fila.ItemArray[1].ToString();
                Datos.Apellidos = _fila.ItemArray[2].ToString();
                Datos.FechaNac = DateTime.Parse(_fila.ItemArray[4].ToString());
                Datos.Telefono = long.Parse(_fila.ItemArray[5].ToString());
                Datos.Email = _fila.ItemArray[6].ToString();
                Datos.Contraseña= _fila.ItemArray[7].ToString();
                Datos.TipoUsuario = int.Parse(_fila.ItemArray[8].ToString());
                Datos.Estatus = _fila.ItemArray[9].ToString();
                Datos.Imagen= _fila.ItemArray[10].ToString();
                
            }
            return Datos;
        }
    }
}
