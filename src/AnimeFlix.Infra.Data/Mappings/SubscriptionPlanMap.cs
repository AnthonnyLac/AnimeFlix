using AnimeFlix.Domain.Models.Plan;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Infra.Data.Mappings
{
    public class SubscriptionPlanMap : IEntityTypeConfiguration<SubscriptionPlanModel>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPlanModel> builder)
        {
            builder.ToTable("SubscriptionPlans"); // Nome da tabela no banco de dados

            builder.HasKey(sp => sp.Id); // Chave primária

            // Mapeamento das propriedades
            builder.Property(sp => sp.Id).HasColumnName("Id");
            builder.Property(sp => sp.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();
            builder.Property(sp => sp.Description).HasColumnName("Description").HasMaxLength(1000).IsRequired();
            builder.Property(sp => sp.Price).HasColumnName("Price").HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(sp => sp.DurationInDays).HasColumnName("DurationInDays").IsRequired();
            builder.Property(sp => sp.IsActive).HasColumnName("IsActive").IsRequired();
        }
    }
}
