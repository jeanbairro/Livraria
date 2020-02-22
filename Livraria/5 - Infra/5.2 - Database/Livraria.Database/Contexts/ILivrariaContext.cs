using Livraria.Domain.Livros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Livraria.Database.Contexts
{
    public interface ILivrariaContext : IDisposable
    {
        DatabaseFacade Database { get; }

        DbSet<Livro> Livros { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}