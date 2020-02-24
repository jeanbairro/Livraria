using Bogus;
using Bogus.Extensions;
using Livraria.Domain.Livros;
using Xunit;

namespace Livraria.Domain.Test.Livros
{
    [CollectionDefinition(nameof(LivroCollection))]
    public class LivroCollection : ICollectionFixture<LivroTestsFixture>
    {
    }

    public class LivroTestsFixture
    {
        private const float _nullWeight = .5f;

        public Livro GetLivroInvalido()
        {
            var livroTests = new Faker<Livro>()
                .CustomInstantiator(f => new Livro(
                    f.Random.AlphaNumeric(Livro.AutorMaxLength + 1).OrNull(f, _nullWeight),
                    f.Random.AlphaNumeric(Livro.EditoraMaxLength + 1).OrNull(f, _nullWeight),
                    f.Random.AlphaNumeric(Livro.TituloMaxLength + 1).OrNull(f, _nullWeight)));

            return livroTests;
        }

        public Livro GetLivroValido()
        {
            var livroTests = new Faker<Livro>()
                .CustomInstantiator(f => new Livro(
                    f.Random.AlphaNumeric(Livro.AutorMaxLength),
                    f.Random.AlphaNumeric(Livro.EditoraMaxLength),
                    f.Random.AlphaNumeric(Livro.TituloMaxLength)));

            return livroTests;
        }
    }
}