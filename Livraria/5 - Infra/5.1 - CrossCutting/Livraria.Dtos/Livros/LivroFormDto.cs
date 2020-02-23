using Livraria.Dtos.Base;

namespace Livraria.Dtos.Livros
{
    public class LivroFormDto : BaseDto
    {
        public string Autor { get; set; }
        public string Editora { get; set; }
        public long Id { get; set; }
        public string Titulo { get; set; }
    }
}