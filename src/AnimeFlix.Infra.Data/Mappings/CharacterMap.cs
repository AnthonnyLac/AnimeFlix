using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.Character;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeFlix.Infra.Data.Mappings
{
    public class CharacterMap : IEntityTypeConfiguration<CharacterModel>
    {
        public void Configure(EntityTypeBuilder<CharacterModel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.ImageUrl).IsRequired();
            builder.HasOne(c => c.Anime)
                .WithMany(a => a.Characters)
                .HasForeignKey(c => c.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
