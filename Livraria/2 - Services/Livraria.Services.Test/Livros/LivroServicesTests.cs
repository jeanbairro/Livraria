using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Livraria.Services.Test.Livros
{
    [Collection(nameof(LivroServicesCollection))]
    public class LivroServicesTests
    {
        public LivroServicesTests(LivroServicesTestsFixture fixture)
        {
            Fixture = fixture;
        }

        public LivroServicesTestsFixture Fixture { get; set; }

        [Fact(DisplayName = "Adiciona um livro com erro")]
        public async Task AdicionarUmLivroComErro()
        {
            var livroServices = Fixture.GetLivroServices();
            var livroDto = Fixture.GetLivroParaAddInvalido();

            var retorno = await livroServices.AddAsync(livroDto);

            Fixture.LivroRepositoryMock.VerifyNoOtherCalls();
            Assert.NotNull(retorno);
            Assert.NotEmpty(retorno.Errors);
        }

        [Fact(DisplayName = "Adiciona um livro com sucesso")]
        public async Task AdicionarUmLivroComSucesso()
        {
            var livroServices = Fixture.GetLivroServices();
            var livroDto = Fixture.GetLivroParaAddValido();

            var retorno = await livroServices.AddAsync(livroDto);

            Fixture.LivroRepositoryMock.Verify();
            Assert.NotNull(retorno);
            Assert.Empty(retorno.Errors);
        }

        [Fact(DisplayName = "Atualiza um livro com erro")]
        public async Task AtualizarUmLivroComErro()
        {
            var livroServices = Fixture.GetLivroServices();
            var livroDto = Fixture.GetLivroParaUpdateInvalido();
            var livro = Fixture.GetLivroById();
            Fixture.LivroRepositoryMock.Setup(c =>
                c.GetByIdAsync(LivroServicesTestsFixture.LivroExistenteId, default))
                .Returns(Task.FromResult(livro));

            var retorno = await livroServices.UpdateAsync(livroDto);

            Fixture.LivroRepositoryMock.Verify(x => x.GetByIdAsync(livroDto.Id, default), Times.Once);
            Fixture.LivroRepositoryMock.Verify(x => x.UpdateAsync(livro, default), Times.Never);
            Assert.NotNull(retorno);
            Assert.NotEmpty(retorno.Errors);
        }

        [Fact(DisplayName = "Atualizar um livro com sucesso")]
        public async Task AtualizarUmLivroComSucesso()
        {
            var livroServices = Fixture.GetLivroServices();
            var livroDto = Fixture.GetLivroParaUpdateValido();
            var livro = Fixture.GetLivroById();
            Fixture.LivroRepositoryMock.Setup(c =>
                c.GetByIdAsync(LivroServicesTestsFixture.LivroExistenteId, default))
                .Returns(Task.FromResult(livro));

            var retorno = await livroServices.UpdateAsync(livroDto);

            Fixture.LivroRepositoryMock.Verify(x => x.GetByIdAsync(livroDto.Id, default), Times.Once);
            Fixture.LivroRepositoryMock.Verify(x => x.UpdateAsync(livro, default), Times.Once);
            Assert.NotNull(retorno);
            Assert.Empty(retorno.Errors);
        }

        [Fact(DisplayName = "Remove um livro com erro")]
        public async Task RemoverUmLivroComErro()
        {
            var livroServices = Fixture.GetLivroServices();
            var livro = Fixture.GetLivroById();
            var livroId = 0;
            Fixture.LivroRepositoryMock.Setup(c =>
                c.GetByIdAsync(LivroServicesTestsFixture.LivroExistenteId, default))
                .Returns(Task.FromResult(livro));

            var retorno = await livroServices.DeleteAsync(livroId);

            Fixture.LivroRepositoryMock.Verify(x => x.GetByIdAsync(livroId, default), Times.Never);
            Fixture.LivroRepositoryMock.Verify(x => x.DeleteAsync(livro, default), Times.Never);

            Assert.False(retorno);
        }

        [Fact(DisplayName = "Remove um livro com sucesso")]
        public async Task RemoverUmLivroComSucesso()
        {
            var livroServices = Fixture.GetLivroServices();
            var livro = Fixture.GetLivroById();
            var livroId = LivroServicesTestsFixture.LivroExistenteId;
            Fixture.LivroRepositoryMock.Setup(c =>
                c.GetByIdAsync(LivroServicesTestsFixture.LivroExistenteId, default))
                .Returns(Task.FromResult(livro));
            Fixture.LivroRepositoryMock.Setup(c => c.DeleteAsync(livro, default)).Returns(Task.FromResult(true));

            var retorno = await livroServices.DeleteAsync(livroId);

            Fixture.LivroRepositoryMock.Verify(x => x.GetByIdAsync(livroId, default), Times.Once);
            Fixture.LivroRepositoryMock.Verify(x => x.DeleteAsync(livro, default), Times.Once);

            Assert.True(retorno);
        }

        [Fact(DisplayName = "Retorna todos os livros")]
        public async Task RetornarTodosOsLivros()
        {
            var livroServices = Fixture.GetLivroServices();
            Fixture.LivroRepositoryMock.Setup(c =>
                c.GetAllAsync(default))
                .Returns(Task.FromResult(Fixture.GetAllLivros()));

            var livros = await livroServices.GetAllAsync();

            Fixture.LivroRepositoryMock.Verify(x => x.GetAllAsync(default), Times.Once);
            Assert.NotNull(livros);
            Assert.NotEmpty(livros);
            Assert.Equal(LivroServicesTestsFixture.CountLivros, livros.Count);
        }
    }
}