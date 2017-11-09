using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class UsuarioBO
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public float Longitud { get; set; }
        public float Latitud { get; set; }
        public DateTime FechaNac { get; set; }
        public long Telefono { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int TipoUsuario { get; set; }
        public int Estatus { get; set; }
        public string Imagen { get; set; }
    }
}