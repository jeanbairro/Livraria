using Livraria.Domain.Livros;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Livraria.Database.Contexts
{
    public class LivrariaContext : DbContext, ILivrariaContext
    {
        private readonly IConfiguration _configuration;

        public LivrariaContext(IConfiguration configuration, DbContextOptions options)
           : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_configuration.GetConnectionString(GetType().Name));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivrariaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}