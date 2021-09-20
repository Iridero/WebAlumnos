using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAlumnos.Models;
using WebAlumnos.Repositories;

namespace WebAlumnos.Controllers
{
    public class HomeController : Controller
    {
        alumnadoContext context;

        public HomeController()
        {
            context = new alumnadoContext();
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AlumnosPorCarrera()
        {
            CarrerasRepository carreras = new CarrerasRepository(context);
            ViewData["Hora"] = DateTime.Now.ToShortTimeString();
            ViewBag.Carreras = carreras.GetCarreras();
            AlumnosRepository alumnos = new AlumnosRepository(context);
            return View(alumnos.GetAlumnos());
        }
        [HttpPost]
        public IActionResult AlumnosPorCarrera([FromForm] string clave)
        {
            CarrerasRepository carreras = new CarrerasRepository(context);
            ViewData["Hora"] = DateTime.Now.ToShortTimeString();
            ViewBag.Carreras = carreras.GetCarreras();
            AlumnosRepository alumnos = new AlumnosRepository(context);
            return View(alumnos.GetAlumnosByCarrera(clave));
        }

        [HttpGet]
        public IActionResult AlumnosPorGenero()
        {
            ViewBag.RadioSelect = "*";
            AlumnosRepository alumnos = new AlumnosRepository(context);
            return View(alumnos.GetAlumnos());
        }
        [HttpPost] 
        public IActionResult AlumnosPorGenero(string sexo)
        {
            AlumnosRepository alumnos = new AlumnosRepository(context);
            ViewBag.RadioSelect = sexo;
            if (sexo=="*")
            {
                return View(alumnos.GetAlumnos());
            }
            else
            {
                return View(alumnos
                    .GetAlumnosBySexo((sexo=="M")?1:2));
            }
        }
    }

}
