using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Core.CoffeeHouse;

namespace DbContext.Configurations.CoffeeHousesConfigurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.Property(b => b.City)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.Country)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.Address)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(b => b.CoffeeChain)
            .WithMany(c => c.Branches)
            .HasForeignKey(b => b.CoffeeChainId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
