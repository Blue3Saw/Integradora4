using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class MensajesBO
    {
        public int UsEnvia { get; set; }
        public int UsRecibe { get; set; }
        public DateTime HoraFecha { get; set; }
        public string Mensaje { get; set; }
        public string Estatus { get; set; }
        public string Titulo { get; set; }
        public int idmensaje { get; set; }
    }
}
