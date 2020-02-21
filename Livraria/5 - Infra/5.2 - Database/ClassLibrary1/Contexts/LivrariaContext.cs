using Livraria.Domain.Livros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

namespace Livraria.Database.Contexts
{
    public class LivrariaContext : DbContext, ILivrariaContext
    {
        public DbSet<Livro> Livros { get; set; }

        public bool AllMigrationsApplied()
        {
            var idsDasMigrationJaExecutadas = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var idsDeTodasAsMigrations = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !idsDeTodasAsMigrations.Except(idsDasMigrationJaExecutadas).Any();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=livraria;Username=postgres;Password=bapecajecarlos");
    }
}