using Livraria.Dtos.Livros;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Livraria.Services.Livros
{
    public interface ILivroServices
    {
        Task<LivroFormDto> AddAsync(LivroFormDto livroDto, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long livroId, CancellationToken cancellationToken = default);

        Task<ICollection<LivroDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<LivroFormDto> UpdateAsync(LivroFormDto livroDto, CancellationToken cancellationToken = default);
    }
}