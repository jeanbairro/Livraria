using Bogus;
using Livraria.Domain.Livros;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Livraria.Domain.Test.Livros
{
    [CollectionDefinition(nameof(LivroCollection))]
    public class LivroCollection : ICollectionFixture<LivroTestsFixture>
    {
    }

    public class LivroTestsFixture
    {
        public Livro GetLivroInvalido()
        {
            var livroTests = new Faker<Livro>()
                .CustomInstantiator(f => new Livro(
                    f.Random.AlphaNumeric(Livro.AutorMaxLength + 1),
                    string.Empty,
                    string.Empty));

            return livroTests;
        }

        public Livro GetLivroValido()
            => GenerateLivro(1).First();

        private static IEnumerable<Livro> GenerateLivro(int quantidade)
        {
            var livroTests = new Faker<Livro>()
                .CustomInstantiator(f => new Livro(
                    f.Random.AlphaNumeric(Livro.AutorMaxLength),
                    f.Random.AlphaNumeric(Livro.EditoraMaxLength),
                    f.Random.AlphaNumeric(Livro.TituloMaxLength)));

            return livroTests.Generate(quantidade);
        }
    }
}