using System.ComponentModel.DataAnnotations;

namespace MVC_P11_EsmeraldaGarcía.Models
{
    public class cursos
    {
        [Key]
        public int? id_cursos { get; set; }
        public string? nombre { get; set; }
    }
}
