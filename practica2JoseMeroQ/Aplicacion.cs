using System;
using System.Collections.Generic;
using System.Text;

namespace practica2JoseMeroQ
{
    public class Aplicacion
    {
        public int IdJob { get; set; }

        public string NombreAplicacion { get; set; }

        public Aplicacion (int IdJob, string NombreAplicacion)
        {
            this.IdJob = IdJob;
            this.NombreAplicacion = NombreAplicacion;
        }
    }
}
