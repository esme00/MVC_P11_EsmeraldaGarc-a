using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;
using MVC_P11_EsmeraldaGarcía.Models;
using System.Diagnostics;

namespace MVC_P11_EsmeraldaGarcía.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public  async Task<ActionResult> SubirArchivo(IFormFile archivo)
        {
            Stream archivoASubir = archivo.OpenReadStream();

            string email = "esmeralda.garcia1@catolica.edu.sv";
            string clave = "abril2024";
            string ruta = "mvcp11esmeraldagarcia.appspot.com";
            string api_key = "AIzaSyBgLO7IwDKSEs6X-9DydDr7LtxN9ztwRqQ";

            var auth = new FirebaseAuthProvider(new FirebaseConfig(api_key));

            var autenticarFireBase = await auth.SignInWithEmailAndPasswordAsync(email, clave);

            var cancellation = new CancellationTokenSource();
            var tokenUser = autenticarFireBase.FirebaseToken;

            var tareaCargarArchivo = new FirebaseStorage(ruta,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(tokenUser),
                    ThrowOnCancel = true
                }).Child("Archivos")
                .Child(archivo.FileName)
                .PutAsync(archivoASubir, cancellation.Token);

            var urlArchivoCargado = await tareaCargarArchivo;

            return RedirectToAction("Index");
        }
    }
}
