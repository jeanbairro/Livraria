using Livraria.Domain.Livros;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Database.Contexts
{
    public interface ILivrariaContext
    {
        DbSet<Livro> Livros { get; set; }

        bool AllMigrationsApplied();
    }
}