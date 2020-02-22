using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Livraria.Domain.Livros;

namespace Livraria.Repository.Livros
{
    public interface ILivroRepository
    {
        Task AddAsync(Livro livro, CancellationToken cancellationToken);
        Task<ICollection<Livro>> GetAsync(CancellationToken cancellationToken);
        Task UpdateAsync(Livro livro, CancellationToken cancellationToken);
    }
}