﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ClasificacionTareaBO
    {
        public int Codigo { get; set; }
        public string Clasificacion { get; set; }
        public string Direccion { get; set; }

        public List<ClasificacionTareaBO> TipoTarea { get; set; }
    }
}
