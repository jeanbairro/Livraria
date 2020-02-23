using Livraria.Domain.Livros;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Livraria.Repository.Livros
{
    public interface ILivroRepository
    {
        Task AddAsync(Livro livro, CancellationToken cancellationToken = default);

        Task<ICollection<Livro>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Livro> GetByIdAsync(long id, CancellationToken cancellationToken = default);

        Task UpdateAsync(Livro livro, CancellationToken cancellationToken = default);
    }
}