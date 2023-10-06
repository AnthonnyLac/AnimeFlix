using AnimeFlix.Domain.Models.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Infra.Data.Mappings
{
    public class UserSubscriptionMap : IEntityTypeConfiguration<UserSubscriptionModel>
    {
        public void Configure(EntityTypeBuilder<UserSubscriptionModel> builder)
        {
            builder.ToTable("UserSubscriptions"); // Nome da tabela no banco de dados

            builder.HasKey(us => us.Id); // Chave primária

            // Mapeamento das propriedades
            builder.Property(us => us.Id).HasColumnName("Id");
            builder.Property(us => us.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(us => us.SubscriptionStartDate).HasColumnName("SubscriptionStartDate").IsRequired();
            builder.Property(us => us.SubscriptionEndDate).HasColumnName("SubscriptionEndDate").IsRequired();
            builder.Property(us => us.PlanId).HasColumnName("PlanId").IsRequired();

            // Relação com a classe UserModel
            builder.HasOne(us => us.User)
                .WithMany()
                .HasForeignKey(us => us.UserId)
                .IsRequired();

            // Relação com a classe SubscriptionPlanModel
            builder.HasOne(us => us.Plan)
                .WithMany()
                .HasForeignKey(us => us.PlanId)
                .IsRequired();
        }
    }
}
