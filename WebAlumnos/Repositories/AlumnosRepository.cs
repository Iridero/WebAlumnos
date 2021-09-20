using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAlumnos.Models;
namespace WebAlumnos.Repositories
{
    public class AlumnosRepository
    {
        alumnadoContext context;
        public AlumnosRepository(alumnadoContext context)
        {
            this.context = context;
        }
        public IEnumerable<Alumno> GetAlumnos()
        {
            return context.Alumnos;
        } 
        public IEnumerable<Alumno> GetAlumnosByCarrera(string clave)
        {
            return context.Alumnos.Where(x => x.Idcarrera == clave);
        }
        public IEnumerable<Alumno> GetAlumnosBySexo(int sexo)
        {
            return context.Alumnos.Where(x => x.Sexo == sexo);
        }
    }
}
