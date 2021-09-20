using System;
using System.Collections.Generic;

#nullable disable

namespace WebAlumnos.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Alumnos = new HashSet<Alumno>();
        }

        public string Clave { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
