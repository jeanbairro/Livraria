using Xunit;

namespace Livraria.Domain.Test.Livros
{
    [Collection(nameof(LivroCollection))]
    public class LivroTests
    {
        public LivroTests(LivroTestsFixture fixture)
        {
            Fixture = fixture;
        }

        public LivroTestsFixture Fixture { get; set; }

        [Fact(DisplayName = "Cria um livro inválido")]
        public void CriarUmLivroInvalido()
        {
            var livro = Fixture.GetLivroInvalido();

            Assert.NotNull(livro);
            Assert.False(livro.IsValid());
            Assert.NotEqual(0, livro.Errors.Count);
        }

        [Fact(DisplayName = "Cria um livro válido")]
        public void CriarUmLivroValido()
        {
            var livro = Fixture.GetLivroValido();
            Assert.NotNull(livro);
            Assert.Empty(livro.Errors);
            Assert.True(livro.IsValid());
        }
    }
}