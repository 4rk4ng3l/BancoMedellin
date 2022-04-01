
namespace BancoMedellin.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Usuario>? Usuarios { get; set; }
    }
}
