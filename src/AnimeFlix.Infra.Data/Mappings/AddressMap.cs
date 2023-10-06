using AnimeFlix.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

namespace AnimeFlix.Infra.Data.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<AddressModel>
    {
        public void Configure(EntityTypeBuilder<AddressModel> builder)
        {
            builder.ToTable("Addres"); // Nome da tabela no banco de dados

            builder.HasKey(a => a.Id); // Chave primária

            builder.Property(a => a.Id).HasColumnName("Id");
            builder.Property(a => a.Street).HasColumnName("Street").HasMaxLength(255).IsRequired();
            builder.Property(a => a.Number).HasColumnName("Number").IsRequired();
            builder.Property(a => a.Complement).HasColumnName("Complement").HasMaxLength(255);
            builder.Property(a => a.City).HasColumnName("City").HasMaxLength(100).IsRequired();
            builder.Property(a => a.State).HasColumnName("State").HasMaxLength(100).IsRequired();
            builder.Property(a => a.Country).HasColumnName("Country").HasMaxLength(100).IsRequired();
            builder.Property(a => a.ZipCode).HasColumnName("ZipCode").HasMaxLength(20).IsRequired();
            builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();

            //Ignorando Props
            builder.Ignore(a => a.User);

            builder.HasOne(a => a.User)
                .WithOne(u => u.Address)
                .HasForeignKey<AddressModel>(a => a.UserId);
        }
    }
}
