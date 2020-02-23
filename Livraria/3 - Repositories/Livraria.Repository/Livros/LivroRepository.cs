using Livraria.Database.Contexts;
using Livraria.Domain.Livros;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Livraria.Repository.Livros
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ILivrariaContext _livrariaContext;

        public LivroRepository(ILivrariaContext livrariaContext)
        {
            _livrariaContext = livrariaContext;
        }

        public async Task AddAsync(Livro livro, CancellationToken cancellationToken = default)
        {
            if (!livro.IsValid()) return;

            await _livrariaContext.Livros.AddAsync(livro);
            await _livrariaContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<ICollection<Livro>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _livrariaContext.Livros.OrderBy(x => x.Titulo).ToListAsync(cancellationToken);

        public async Task<Livro> GetByIdAsync(long id, CancellationToken cancellationToken = default)
            => await _livrariaContext.Livros.FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Livro livro, CancellationToken cancellationToken = default)
        {
            if (!livro.IsValid()) return;

            var entry = _livrariaContext.Livros.Attach(livro);
            entry.State = EntityState.Modified;
            await _livrariaContext.SaveChangesAsync(cancellationToken);
        }
    }
}