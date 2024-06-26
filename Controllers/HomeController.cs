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
            //Leemos el archivo subido
            Stream archivoASubir = archivo.OpenReadStream();

            //ConfigurationRoot la conexion hacia FareBase
            string email = "esmeralda.garcia1@catolica.edu.sv"; /*Correo para autenticar en FireBase*/
            string clave = "abril2024";     //Contraseña establecida en ela auticacion en FireBase
            string ruta = "mvcp11esmeraldagarcia.appspot.com";   // URL donde se guardaran los arhivos
            string api_key = "AIzaSyBgLO7IwDKSEs6X-9DydDr7LtxN9ztwRqQ";  //API_KEY indentificador del proyecto en FireBase

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
