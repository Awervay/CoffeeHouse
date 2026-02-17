using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.DAL.Staff;

namespace DbContext.Configurations.CoffeeHousesConfigurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

}
