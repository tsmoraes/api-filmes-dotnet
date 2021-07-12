using Microsoft.EntityFrameworkCore;

namespace CatalogoAPI.Models
{
    public class CatalogoContext : DbContext
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options)
            : base(options)
        {
        }

        public DbSet<CatalogoFilme> CatalogoFilmes { get; set; }
    }
}