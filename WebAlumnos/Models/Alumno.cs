using System;
using System.Collections.Generic;

#nullable disable

namespace WebAlumnos.Models
{
    public partial class Alumno
    {
        public string Control { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombre { get; set; }
        public byte Sexo { get; set; }
        public string Idcarrera { get; set; }
        public uint Entrada { get; set; }

        public virtual Carrera IdcarreraNavigation { get; set; }
    }
}
