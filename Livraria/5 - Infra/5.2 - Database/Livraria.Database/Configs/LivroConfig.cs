using Livraria.Domain.Livros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Database.Configs
{
    public class LivroConfig : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(Livro));

            builder.Property(x => x.Autor).HasMaxLength(Livro.AutorMaxLength).IsRequired();
            builder.Property(x => x.Editora).HasMaxLength(Livro.EditoraMaxLength).IsRequired();
            builder.Property(x => x.Titulo).HasMaxLength(Livro.TituloMaxLength).IsRequired();

            builder.HasIndex(x => x.Id);
        }
    }
}