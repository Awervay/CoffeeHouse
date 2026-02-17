using Core.DAL.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
