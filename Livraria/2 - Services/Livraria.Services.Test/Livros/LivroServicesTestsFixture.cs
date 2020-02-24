using AutoMoq;
using Bogus;
using Bogus.Extensions;
using Livraria.Domain.Livros;
using Livraria.Dtos.Livros;
using Livraria.Repository.Livros;
using Livraria.Services.Livros;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Livraria.Services.Test.Livros
{
    [CollectionDefinition(nameof(LivroServicesCollection))]
    public class LivroServicesCollection : ICollectionFixture<LivroServicesTestsFixture>
    {
    }

    public class LivroServicesTestsFixture
    {
        public const int CountLivros = 50;
        public const long LivroExistenteId = 1;
        private const float _nullWeight = .5f;
        public Mock<ILivroRepository> LivroRepositoryMock { get; set; }
        public Mock<ILivroServices> LivroServicesMock { get; set; }

        public ICollection<Livro> GetAllLivros()
            => GenerateLivros(CountLivros).ToList();

        public Livro GetLivroById()
        {
            var livro = GenerateLivros(1).First();
            livro.Id = LivroExistenteId;
            return livro;
        }

        public LivroFormDto GetLivroParaAddInvalido()
            => GetLivroInvalido();

        public LivroFormDto GetLivroParaAddValido()
                    => GetLivroValido();

        public LivroFormDto GetLivroParaUpdateInvalido()
        {
            var livroTests = GetLivroInvalido()
                .RuleFor(x => x.Id, f => LivroExistenteId);

            return livroTests;
        }

        public LivroFormDto GetLivroParaUpdateValido()
        {
            var livroTests = GetLivroValido()
                .RuleFor(x => x.Id, f => LivroExistenteId);

            return livroTests;
        }

        public LivroServices GetLivroServices()
        {
            var mocker = new AutoMoqer();
            mocker.Create<LivroServices>();
            var service = mocker.Resolve<LivroServices>();

            LivroRepositoryMock = mocker.GetMock<ILivroRepository>();
            LivroServicesMock = mocker.GetMock<ILivroServices>();

            return service;
        }

        private static ICollection<Livro> GenerateLivros(int quantidade)
        {
            var livroTests = new Faker<Livro>()
                .CustomInstantiator(f => new Livro(
                    f.Random.AlphaNumeric(Livro.AutorMaxLength),
                    f.Random.AlphaNumeric(Livro.EditoraMaxLength),
                    f.Random.AlphaNumeric(Livro.TituloMaxLength)));

            return livroTests.Generate(quantidade);
        }

        private Faker<LivroFormDto> GetLivroInvalido()
        {
            var livroTests = new Faker<LivroFormDto>()
                .RuleFor(x => x.Autor, f => f.Random.AlphaNumeric(Livro.AutorMaxLength + 1).OrNull(f, _nullWeight))
                .RuleFor(x => x.Editora, f => f.Random.AlphaNumeric(Livro.EditoraMaxLength + 1).OrNull(f, _nullWeight))
                .RuleFor(x => x.Titulo, f => f.Random.AlphaNumeric(Livro.TituloMaxLength + 1).OrNull(f, _nullWeight));

            return livroTests;
        }

        private Faker<LivroFormDto> GetLivroValido()
        {
            var livroTests = new Faker<LivroFormDto>()
                .RuleFor(x => x.Autor, f => f.Random.AlphaNumeric(Livro.AutorMaxLength))
                .RuleFor(x => x.Editora, f => f.Random.AlphaNumeric(Livro.EditoraMaxLength))
                .RuleFor(x => x.Titulo, f => f.Random.AlphaNumeric(Livro.TituloMaxLength));

            return livroTests;
        }
    }
}