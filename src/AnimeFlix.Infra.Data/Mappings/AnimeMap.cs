using AnimeFlix.Domain.Enum;
using AnimeFlix.Domain.Models.Anime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeFlix.Infra.Data.Mappings
{
    public class AnimeMap : IEntityTypeConfiguration<AnimeModel>
    {
        public void Configure(EntityTypeBuilder<AnimeModel> builder)
        {
            builder.ToTable("Animes"); // Nome da tabela no banco de dados

            builder.HasKey(a => a.Id); // Chave primária

            // Mapeamento das propriedades
            builder.Property(a => a.Id).HasColumnName("Id");
            builder.Property(a => a.Title).HasColumnName("Title").HasMaxLength(255).IsRequired();
            builder.Property(a => a.Description).HasColumnName("Description").HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Genre).HasColumnName("Genre").IsRequired();
            builder.Property(a => a.ReleaseYear).HasColumnName("ReleaseYear").IsRequired();
            builder.Property(a => a.CoverImage).HasColumnName("CoverImage").HasMaxLength(255).IsRequired();
            builder.Property(a => a.Trailer).HasColumnName("Trailer").HasMaxLength(255).IsRequired();

            //Ignorando Props
            builder.Ignore(a => a.Rating);
            builder.Ignore(a => a.AnimeEpisodes);

            // Mapeamento do enum AnimeCetegory para string (no banco de dados)
            builder.Property(a => a.Genre)
                .HasConversion(
                    v => v.ToString(),
                    v => (AnimeCetegory)Enum.Parse(typeof(AnimeCetegory), v)
                );
        }
    }
}
