using Livraria.Domain.Livros;
using Xunit;

namespace Livraria.Domain.Test.Livros
{
    public class LivroBuilderTest
    {
        [Fact(DisplayName = "Cria um livro válido pelo builder")]
        public void CriarUmaSolicitacaoValida()
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

        [Fact(DisplayName = "Cria um livro inválido pelo builder")]
        public void CriarUmLivroInvalido()
        {
            var builder = GetBuilder();
            var livro = builder.Build();

            Assert.NotNull(livro);
            //TODO: Adicionar teste da quantidade de erros.
            Assert.False(livro.IsValid());
        }

        private LivroBuilder GetBuilder() => new LivroBuilder();
    }
}