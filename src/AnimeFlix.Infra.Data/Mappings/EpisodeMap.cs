using AnimeFlix.Domain.Models.Anime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Infra.Data.Mappings
{
    public class EpisodeMap : IEntityTypeConfiguration<EpisodeModel>
    {
        public void Configure(EntityTypeBuilder<EpisodeModel> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.EpisodeNumber).IsRequired();
            builder.Property(e => e.Title).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.VideoUrl).IsRequired();
            builder.Property(e => e.Duration).IsRequired();

            // Define o relacionamento com o AnimeModel (um episódio pertence a um Anime)
            builder.HasOne(e => e.Anime)
                .WithMany(a => a.AnimeEpisodes)
                .HasForeignKey(e => e.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
