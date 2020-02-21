using Livraria.Domain.Base;

namespace Livraria.Domain.Livros
{
    public class Livro : EntityBase
    {
        public const int AutorMaxLength = 200;
        public const int EditoraMaxLength = 200;
        public const int TituloMaxLength = 200;

        public Livro(string autor, string editora, string titulo)
            : base()
        {
            SetAutor(autor);
            SetEditora(editora);
            SetTitulo(titulo);
        }

        public string Autor { get; private set; }
        public string Editora { get; private set; }
        public string Titulo { get; private set; }

        public void SetAutor(string autor)
        {
            if (string.IsNullOrWhiteSpace(autor))
            {
                AddError("O autor do livro é obrigatório.");
                return;
            }

            if (autor.Length > AutorMaxLength)
            {
                AddError($"Informe um autor com no máximo {AutorMaxLength} caracteres.");
                return;
            }

            Autor = autor;
        }

        public void SetEditora(string editora)
        {
            if (string.IsNullOrWhiteSpace(editora))
            {
                AddError("A editora do livro é obrigatória.");
                return;
            }

            if (editora.Length > EditoraMaxLength)
            {
                AddError($"Informe uma editora com no máximo {EditoraMaxLength} caracteres.");
                return;
            }

            Editora = editora;
        }

        public void SetTitulo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                AddError("O título do livro é obrigatório.");
                return;
            }

            if (titulo.Length > TituloMaxLength)
            {
                AddError($"Informe um título com no máximo {TituloMaxLength} caracteres.");
                return;
            }

            Titulo = titulo;
        }
    }
}