﻿using System;
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
        int valor = 0;

        public int AgregarUsuario(object ObjU)
        {
            UsuarioBO Dato = (UsuarioBO)ObjU;
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO Usuarios (Nombre, Apellidos, Direccion, FechaNac, Telefono, Email, Contraseña, TipoUs, Estatus, Imagen,QR) VALUES (@Nombre, @Apellidos, @Direccion, @FechaNac, @Telefono, @Email, @Contraseña, @TipoUs, 'Activo', @Imagen, @QR)");
            SentenciaSQL.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Dato.Nombre;
            SentenciaSQL.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = Dato.Apellidos;
            SentenciaSQL.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Dato.Direccion;
            SentenciaSQL.Parameters.Add("@FechaNac", SqlDbType.Date).Value = Dato.FechaNac;
            SentenciaSQL.Parameters.Add("@Telefono", SqlDbType.BigInt).Value = Dato.Telefono;
            SentenciaSQL.Parameters.Add("@Email", SqlDbType.VarChar).Value = Dato.Email;
            SentenciaSQL.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Dato.Encriptar(Dato.Contraseña);
            SentenciaSQL.Parameters.Add("@TipoUs", SqlDbType.Int).Value = Dato.TipoUsuario;
            SentenciaSQL.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = Dato.Imagen;
            SentenciaSQL.Parameters.Add("@QR", SqlDbType.VarChar).Value = Dato.QR;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int AgregarEmpleador(object ObjU)
        {
            UsuarioBO Dato = (UsuarioBO)ObjU;
            SqlCommand SentenciaSQL = new SqlCommand("INSERT INTO Usuarios (Nombre, Apellidos, Direccion, FechaNac, Telefono, Email, Contraseña, TipoUs, Estatus, Imagen) VALUES (@Nombre, @Apellidos, @Direccion, @FechaNac, @Telefono, @Email, @Contraseña, @TipoUs, 'En revisión', @Imagen)");
            SentenciaSQL.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Dato.Nombre;
            SentenciaSQL.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = Dato.Apellidos;
            SentenciaSQL.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Dato.Direccion;
            SentenciaSQL.Parameters.Add("@FechaNac", SqlDbType.Date).Value = Dato.FechaNac;
            SentenciaSQL.Parameters.Add("@Telefono", SqlDbType.BigInt).Value = Dato.Telefono;
            SentenciaSQL.Parameters.Add("@Email", SqlDbType.VarChar).Value = Dato.Email;
            SentenciaSQL.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Dato.Encriptar(Dato.Contraseña);
            SentenciaSQL.Parameters.Add("@TipoUs", SqlDbType.Int).Value = Dato.TipoUsuario;
            SentenciaSQL.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = Dato.Imagen;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int ActualizarUsuario(object ObjU)
        {
            UsuarioBO Dato = (UsuarioBO)ObjU;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Usuarios SET Nombre = @Nombre, Apellidos = @Apellidos, Direccion = @Direccion, FechaNac = @FechaNac, Telefono = @Telefono, Email = @Email, Contraseña = @Contraseña, TipoUs = @TipoUs, Estatus = 'En revisión', Imagen = @Imagen WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Dato.Nombre;
            SentenciaSQL.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = Dato.Apellidos;
            SentenciaSQL.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Dato.Direccion;
            SentenciaSQL.Parameters.Add("@FechaNac", SqlDbType.Date).Value = Dato.FechaNac;
            SentenciaSQL.Parameters.Add("@Telefono", SqlDbType.BigInt).Value = Dato.Telefono;
            SentenciaSQL.Parameters.Add("@Email", SqlDbType.VarChar).Value = Dato.Email;
            SentenciaSQL.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Dato.Encriptar(Dato.Contraseña);
            SentenciaSQL.Parameters.Add("@TipoUs", SqlDbType.Int).Value = Dato.TipoUsuario;
            SentenciaSQL.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = "Hola.jpg";
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }

        public int ActualizarPerfil(object ObjU)
        {
            UsuarioBO Dato = (UsuarioBO)ObjU;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Usuarios SET Nombre = @Nombre, Apellidos = @Apellidos, Direccion = @Direccion, FechaNac = @FechaNac, Telefono = @Telefono, Email = @Email, Contraseña = @Contraseña, Estatus = 'En revisión', Imagen = @Imagen WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Dato.Nombre;
            SentenciaSQL.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = Dato.Apellidos;
            SentenciaSQL.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Dato.Direccion;
            SentenciaSQL.Parameters.Add("@FechaNac", SqlDbType.Date).Value = Dato.FechaNac;
            SentenciaSQL.Parameters.Add("@Telefono", SqlDbType.BigInt).Value = Dato.Telefono;
            SentenciaSQL.Parameters.Add("@Email", SqlDbType.VarChar).Value = Dato.Email;
            SentenciaSQL.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Dato.Encriptar(Dato.Contraseña);
            SentenciaSQL.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = "Hola.jpg";
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
            Com.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Datos.Encriptar(Datos.Contraseña);
            Com.CommandType = CommandType.Text;
            return Conex.EjecutarComando(Com);
        }

        public int LoginEstudiante(object ObjU)
        {
            UsuarioBO Datos = (UsuarioBO)ObjU;
            SqlCommand Com = new SqlCommand("SELECT * FROM Usuarios WHERE Email = @Email AND Contraseña = @Contraseña AND TipoUs = 3");
            Com.Parameters.Add("@Email", SqlDbType.VarChar).Value = Datos.Email;
            Com.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Datos.Encriptar(Datos.Contraseña);
            Com.CommandType = CommandType.Text;
            return Conex.EjecutarComando(Com);
        }

        public int LoginEmpleador(object ObjU)
        {
            UsuarioBO Datos = (UsuarioBO)ObjU;
            SqlCommand Com = new SqlCommand("SELECT * FROM Usuarios WHERE Email = @Email AND Contraseña = @Contraseña AND TipoUs = 2");
            Com.Parameters.Add("@Email", SqlDbType.VarChar).Value = Datos.Email;
            Com.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Datos.Encriptar(Datos.Contraseña);
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
            valor = int.Parse(lol["Codigo"].ToString());

            return valor;
        }

        public UsuarioBO PerfilUsuario(int Codigo)
        {
            UsuarioBO Datos = new UsuarioBO();
            SqlCommand Com = new SqlCommand("SELECT * FROM Usuarios U WHERE U.Codigo = @Codigo");
            Com.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
            Com.CommandType = CommandType.Text;

            var _fila = Conex.EjecutarSentencia(Com).Tables[0].Rows[0];
            {
                Datos.Codigo = int.Parse(_fila.ItemArray[0].ToString());
                Datos.Nombre = _fila.ItemArray[1].ToString();
                Datos.Apellidos = _fila.ItemArray[2].ToString();
                Datos.FechaNac = DateTime.Parse(_fila.ItemArray[3].ToString());
                Datos.Direccion = _fila.ItemArray[4].ToString();
                Datos.Telefono = long.Parse(_fila.ItemArray[5].ToString());
                Datos.Email = _fila.ItemArray[6].ToString();
                Datos.Contraseña = Datos.Desencriptar(_fila.ItemArray[7].ToString());
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
        //contine los datos de los estudiantes
        public DataTable TablaUsuarios3(int id)
        {
            UsuarioBO Datos = new UsuarioBO();
            Datos.Codigo = id;
            sentencia = "SELECT * FROM Usuarios where Codigo='" + Datos.Codigo + "'";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            return tablavirtual;
        }


        public int ActualizarUsuario2(object ObjU)
        {
            UsuarioBO Dato = (UsuarioBO)ObjU;
            SqlCommand SentenciaSQL = new SqlCommand("UPDATE Usuarios SET Nombre = @Nombre, Apellidos = @Apellidos, FechaNac = @FechaNac, Telefono = @Telefono, Email = @Email, Contraseña = @Contraseña,Direccion= @Direccion,Estatus = 'Activo', Imagen = @Imagen WHERE Codigo = @Codigo");
            SentenciaSQL.Parameters.Add("@Codigo", SqlDbType.Int).Value = Dato.Codigo;
            SentenciaSQL.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Dato.Nombre;
            SentenciaSQL.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = Dato.Apellidos;
            SentenciaSQL.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Dato.Direccion;
            SentenciaSQL.Parameters.Add("@FechaNac", SqlDbType.Date).Value = Dato.FechaNac;
            SentenciaSQL.Parameters.Add("@Telefono", SqlDbType.BigInt).Value = Dato.Telefono;
            SentenciaSQL.Parameters.Add("@Email", SqlDbType.VarChar).Value = Dato.Email;
            SentenciaSQL.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Dato.Encriptar(Dato.Contraseña);
            SentenciaSQL.Parameters.Add("@Imagen", SqlDbType.VarChar).Value =Dato.Imagen;
            SentenciaSQL.CommandType = CommandType.Text;
            return Conex.EjecutarComando(SentenciaSQL);
        }


        public string Buscarnombre(UsuarioBO datos)
        {
            sentencia = "select (Nombre + ' ' + Apellidos) as Nombre from Usuarios where Email='" + datos.Email+"'";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            DataRow lol = tablavirtual.Rows[0];
            string valor = lol["Nombre"].ToString();

            return valor;
        }

        public DataTable UsuariosReporte()
        {
            sentencia = "SELECT U.Codigo, (U.Nombre + ' ' + U.Apellidos) AS 'Nombre', U.FechaNac, U.Direccion, U.Telefono, U.Email, TU.Tipo, U.Estatus FROM Usuarios U INNER JOIN TipoUsuario TU ON U.TipoUs = TU.Codigo";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            return tablavirtual;
        }

        //datos para la pagina principal (mas especifico la parte del index del administrador)

        public int Empleadores()
        {
            sentencia = "SELECT COUNT(TipoUs)AS Empleadores FROM Usuarios where TipoUs=2";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
             valor = int.Parse(tablavirtual.Rows[0][0].ToString());
            return valor;
        }

        public int Estudiantes()
        {
            sentencia = "SELECT COUNT(TipoUs)AS Estudiantes FROM Usuarios where TipoUs=3";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            valor = int.Parse(tablavirtual.Rows[0][0].ToString());
            return valor;
        }

        public int MensajesSinleer(int codigoadm)
        {
            sentencia = "SELECT COUNT(Estatus)AS Mensajes FROM Mensajes where Estatus=1 and UsRecibe='"+codigoadm+"'";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            valor = int.Parse(tablavirtual.Rows[0][0].ToString());
            return valor;
        }

        public int tareasverificar()
        {
            sentencia = "SELECT COUNT(Estatus)AS Estudiantes FROM Tareas where Estatus=3";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            valor = int.Parse(tablavirtual.Rows[0][0].ToString());
            return valor;
        }
        public int tareasEnjecucion()
        {
            sentencia = "SELECT COUNT(Estatus)AS Estudiantes FROM Tareas where Estatus=5";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            valor = int.Parse(tablavirtual.Rows[0][0].ToString());
            return valor;
        }
        public int tareasRechazadas()
        {
            sentencia = "SELECT COUNT(Estatus)AS Estudiantes FROM Tareas where Estatus=2";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            valor = int.Parse(tablavirtual.Rows[0][0].ToString());
            return valor;
        }


        //metodos para la vista donde el empleador ve el perfil del alumno


    }
}
