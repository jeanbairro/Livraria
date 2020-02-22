using Livraria.Domain.Livros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Livraria.Database.Contexts
{
    public interface ILivrariaContext : IDisposable
    {
        DatabaseFacade Database { get; }
        DbSet<Livro> Livros { get; set; }
    }
}