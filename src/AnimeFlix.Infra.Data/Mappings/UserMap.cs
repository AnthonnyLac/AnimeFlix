using AnimeFlix.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeFlix.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Users"); // Nome da tabela no banco de dados

            builder.HasKey(a => a.Id); // Chave primária

            // Mapeamento das propriedades
            builder.Property(a => a.Id).HasColumnName("Id");
            builder.Property(a => a.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();
            builder.Property(a => a.Bio).HasColumnName("Bio").HasMaxLength(1000).IsRequired();
            builder.Property(a => a.Email).HasColumnName("Email").IsRequired();
            builder.Property(a => a.Phone).HasColumnName("Phone").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt").IsRequired().HasDefaultValueSql("GETDATE()");


            //Ignorando Props
            builder.Ignore(a => a.FavoriteAnimes);
            builder.Ignore(a => a.FavoriteCharacters);

        }
    }
}
