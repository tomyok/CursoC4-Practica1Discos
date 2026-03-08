using Discos_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Discos_EF.Data
{
    public class DiscosDbContext : DbContext
    {
        public DiscosDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Disco> Discos { get; set; }
        public DbSet<Estilo> Estilos { get; set; }
        public DbSet<TipoEdicion> TipoEdiciones { get; set; }

    }
}
