namespace Livraria.Domain.Livros
{
    public class LivroBuilder
    {
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Titulo { get; set; }

        public Livro Build()
            => new Livro(Autor, Editora, Titulo);

        public LivroBuilder WithAutor(string autor)
        {
            Autor = autor;
            return this;
        }

        public LivroBuilder WithEditora(string editora)
        {
            Editora = editora;
            return this;
        }

        public LivroBuilder WithTitulo(string titulo)
        {
            Titulo = titulo;
            return this;
        }
    }
}