using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class TareasBO
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public int CodigoEmpleador { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public int TipoTarea { get; set; }
        public string Descripcion { get; set; }
        public int CodigoEstatus { get; set; }
    }
}
