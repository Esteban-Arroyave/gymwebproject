using Microsoft.EntityFrameworkCore;
using gymwebproject.Models; // Aquí están tus modelos, como Suscripcion

namespace gymwebproject.Repositorio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<gestionmodel> suscripciones { get; set; }
        // Agrega aquí más DbSets si tienes otros modelos (por ejemplo, Usuarios, Pagos, etc.)
    }
}
