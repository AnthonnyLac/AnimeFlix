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
    public class RatingMap : IEntityTypeConfiguration<RatingModel>
    {
        public void Configure(EntityTypeBuilder<RatingModel> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.AverageRating).IsRequired();
            builder.Property(r => r.TotalRatings).IsRequired();
            builder.Property(r => r.LastUpdated).IsRequired();

            // Define o relacionamento com o AnimeModel (um rating pertence a um Anime)
            builder.HasOne(r => r.Anime)
                .WithMany(a => a.Ratings)
                .HasForeignKey(r => r.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
