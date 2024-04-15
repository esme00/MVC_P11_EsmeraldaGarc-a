using System.ComponentModel.DataAnnotations;

namespace MVC_P11_EsmeraldaGarcía.Models
{
    public class dato
    {
        [Key]

        public int? id_dato { get; set; }
        public string? name_user { get; set; }
        public string? password { get; set; }
        public string? genero { get; set; }
        public string? direction { get; set; }
        public string? pasatiempo { get; set; }
        public string? id_cursos { get; set; }
        public string? conocimientos { get; set; }

    }
}
