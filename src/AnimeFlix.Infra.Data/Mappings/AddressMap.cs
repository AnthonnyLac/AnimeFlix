using AnimeFlix.Domain.Models.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeFlix.Infra.Data.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<AddressModel>
    {
        public void Configure(EntityTypeBuilder<AddressModel> builder)
        {
            builder.ToTable("Addresses"); // Nome da tabela no banco de dados

            builder.HasKey(a => a.Id); // Chave primária

            // Mapeamento das propriedades
            builder.Property(a => a.Id).HasColumnName("Id");
            builder.Property(a => a.Street).HasColumnName("Street").HasMaxLength(255).IsRequired();
            builder.Property(a => a.Number).HasColumnName("Number").HasMaxLength(24).IsRequired();
            builder.Property(a => a.City).HasColumnName("City").HasMaxLength(255).IsRequired();
            builder.Property(a => a.State).HasColumnName("State").HasMaxLength(255).IsRequired();
            builder.Property(a => a.Country).HasColumnName("Country").HasMaxLength(255).IsRequired();
            builder.Property(a => a.ZipCode).HasColumnName("ZipCode").HasMaxLength(255).IsRequired();

            //Ignorando Props
            builder.Ignore(a => a.Complement);

         
        }
    }
}
