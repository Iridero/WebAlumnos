using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAlumnos.Models;
namespace WebAlumnos.Repositories
{
    public class CarrerasRepository
    {
        alumnadoContext context;

        public CarrerasRepository(alumnadoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Carrera> GetCarreras()
        {
            return context.Carreras;
        }
    }
}
