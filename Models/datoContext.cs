using Microsoft.EntityFrameworkCore;

namespace MVC_P11_EsmeraldaGarcía.Models
{
    public class datoContext  : DbContext
    {
        public datoContext(DbContextOptions<datoContext> options) : base(options)
        {


        }
        public DbSet<cursos> cursos { get; set; }
        public DbSet<dato> dato { get; set; }
    }
}
