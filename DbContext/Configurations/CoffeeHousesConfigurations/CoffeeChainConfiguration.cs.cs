using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Core.CoffeeHouse;

namespace DbContext.Configurations.CoffeeHousesConfigurations;

public class CoffeeChainConfiguration : IEntityTypeConfiguration<CoffeeChain>
{
    public void Configure(EntityTypeBuilder<CoffeeChain> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
