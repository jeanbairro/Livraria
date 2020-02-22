using Livraria.Domain.Livros;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Database.Contexts
{
    public class LivrariaContext : DbContext, ILivrariaContext
    {
        public LivrariaContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=livraria;Username=postgres;Password=senha");
    }
}