using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Core.CoffeeHouse;

namespace DbContext.Configurations.CoffeeHousesConfigurations;

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .HasMaxLength(300);

        builder.Property(p => p.StartDate)
            .IsRequired();

        builder.Property(p => p.EndDate)
            .IsRequired();

        builder.HasOne(p => p.Branch)
            .WithMany(b => b.Promotions)
            .HasForeignKey(p => p.BranchId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

