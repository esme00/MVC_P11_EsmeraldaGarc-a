using Microsoft.AspNetCore.Mvc;
using MVC_P11_EsmeraldaGarcía.Models;

namespace MVC_P11_EsmeraldaGarcía.Controllers
{
    public class datossController : Controller
    {
        public IActionResult Index()
        {
            var listadodedato = (from e in _datoContext.dato
                                 select new
                                 {
                                     Nombre = e.name_user,
                                     Descripcion = e.direction,
                                     Genero = e.genero,
                                     Cursos = e.id_cursos,
                                     Pasatiempo = e.pasatiempo
                                 }).ToList();
            ViewData["listadodedato"] = listadodedato;
            return View();
        }
        public IActionResult Crear(dato nuevodato)
        {
            _datoContext.Add(nuevodato);
            _datoContext.SaveChanges();

            return RedirectToAction("Index");
        }



        private readonly datoContext _datoContext;
        public datossController(datoContext datoContext)
        {
            _datoContext = datoContext;
        }

    }
}

