using Livraria.Domain.Livros;
using Livraria.Dtos.Livros;
using Livraria.Repository.Livros;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Livraria.Services.Livros
{
    public class LivroServices : ILivroServices
    {
        private readonly ILivroRepository _livroRepository;

        public LivroServices(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<LivroFormDto> AddAsync(LivroFormDto livroDto, CancellationToken cancellationToken = default)
        {
            var livro = new LivroBuilder()
                .WithAutor(livroDto.Autor)
                .WithEditora(livroDto.Editora)
                .WithTitulo(livroDto.Titulo)
                .Build();

            if (!livro.IsValid())
            {
                livroDto.AddErrors(livro.Errors);
                return livroDto;
            }

            await _livroRepository.AddAsync(livro, cancellationToken);
            return livroDto;
        }

        public async Task<ICollection<LivroDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var livros = await _livroRepository.GetAllAsync(cancellationToken);
            return livros.Select(x => new LivroDto
            {
                Autor = x.Autor,
                Id = x.Id,
                Titulo = x.Titulo
            }).ToList();
        }

        public async Task<LivroFormDto> UpdateAsync(LivroFormDto livroDto, CancellationToken cancellationToken = default)
        {
            var livro = await _livroRepository.GetByIdAsync(livroDto.Id);
            if (livro is null)
            {
                livroDto.AddError("Você precisa informar um livro.");
                return livroDto;
            }

            livro.SetAutor(livroDto.Autor);
            livro.SetEditora(livroDto.Editora);
            livro.SetTitulo(livroDto.Titulo);

            if (!livro.IsValid())
            {
                livroDto.AddErrors(livro.Errors);
                return livroDto;
            }

            await _livroRepository.UpdateAsync(livro, cancellationToken);
            return livroDto;
        }
    }
}