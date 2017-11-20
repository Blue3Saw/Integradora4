using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class UsuarioBO
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNac { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int TipoUsuario { get; set; }
        public string Estatus { get; set; }
        public string Imagen { get; set; }
        public string Encriptar(string str)
        {
            string Resultado = string.Empty;
            Byte[] Encriptado = System.Text.Encoding.Unicode.GetBytes(str);
            Resultado = Convert.ToBase64String(Encriptado);
            return Resultado;
        }

        public string Desencriptar(string str)
        {
            string Resultado = string.Empty;
            Byte[] Desencriptado = Convert.FromBase64String(str);
            Resultado = System.Text.Encoding.Unicode.GetString(Desencriptado);
            return Resultado;
        }
    }
}