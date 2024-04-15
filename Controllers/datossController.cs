using Microsoft.AspNetCore.Mvc;
using MVC_P11_EsmeraldaGarcía.Models;

namespace MVC_P11_EsmeraldaGarcía.Controllers
{
    public class datossController : Controller
    {
        
        public IActionResult Index()
        {
            //Para mostrar en la tabka
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
              //Crear y guardar los nuevos datos
            _datoContext.Add(nuevodato);
            _datoContext.SaveChanges();

            //retorna al index
            return RedirectToAction("Index");
        }



        private readonly datoContext _datoContext;
        public datossController(datoContext datoContext)
        {
            _datoContext = datoContext;
        }

    }
}

