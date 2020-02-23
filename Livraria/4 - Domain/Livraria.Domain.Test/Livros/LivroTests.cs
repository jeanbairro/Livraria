using Livraria.Domain.Livros;
using Xunit;

namespace Livraria.Domain.Test.Livros
{
    public class LivroTests
    {
        [Fact(DisplayName = "Cria um livro inválido pelo builder")]
        public void CriarUmLivroInvalido()
        {
            var builder = GetBuilder();
            var livro = builder.Build();

            Assert.NotNull(livro);
            Assert.False(livro.IsValid());
            Assert.NotEqual(0, livro.Errors.Count);
        }

        [Fact(DisplayName = "Cria um livro válido pelo builder")]
        public void CriarUmLivroValido()
        {
            var builder = GetBuilder();
            var livro = builder
                .WithAutor("J. K. Rowling")
                .WithEditora("Rocco")
                .WithTitulo("Harry potter e a pedra filosofal")
                .Build();

            Assert.NotNull(livro);
            Assert.Empty(livro.Errors);
            Assert.Equal("J. K. Rowling", livro.Autor);
            Assert.Equal("Rocco", livro.Editora);
            Assert.Equal("Harry potter e a pedra filosofal", livro.Titulo);
            Assert.True(livro.IsValid());
        }

        private LivroBuilder GetBuilder() => new LivroBuilder();
    }
}