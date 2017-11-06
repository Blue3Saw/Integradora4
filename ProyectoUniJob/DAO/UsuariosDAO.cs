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
    class UsuariosDAO
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
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Usuarios SET Estatus = 'Inactivo' WHERE Codigo = @Codigo");
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
        public DataSet LoginAdministrador(object ObjU)
        {
            UsuarioBO Datos = (UsuarioBO)ObjU;
            SqlCommand Com = new SqlCommand("SELECT * FROM Usuarios WHERE Email = @Email AND Contraseña = @Contraseña AND TipoUs = 1");
            Com.Parameters.Add("@Email", SqlDbType.VarChar).Value = Datos.Email;
            Com.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Datos.Contraseña;
            Com.CommandType = CommandType.Text;
            return Conex.EjecutarSentencia(Com);
        }

        public DataSet LoginEstudiante(object ObjU)
        {
            UsuarioBO Datos = (UsuarioBO)ObjU;
            SqlCommand Com = new SqlCommand("SELECT * FROM Usuarios WHERE Email = @Email AND Contraseña = @Contraseña AND TipoUs = 3");
            Com.Parameters.Add("@Email", SqlDbType.VarChar).Value = Datos.Email;
            Com.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Datos.Contraseña;
            Com.CommandType = CommandType.Text;
            return Conex.EjecutarSentencia(Com);
        }

        public DataSet LoginEmpleador(object ObjU)
        {
            UsuarioBO Datos = (UsuarioBO)ObjU;
            SqlCommand Com = new SqlCommand("SELECT * FROM Usuarios WHERE Email = @Email AND Contraseña = @Contraseña AND TipoUs = 2");
            Com.Parameters.Add("@Email", SqlDbType.VarChar).Value = Datos.Email;
            Com.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Datos.Contraseña;
            Com.CommandType = CommandType.Text;
            return Conex.EjecutarSentencia(Com);
        }
    }
}
