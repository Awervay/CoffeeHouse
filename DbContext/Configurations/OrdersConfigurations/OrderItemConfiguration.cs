using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Core.CoffeeHouse;

namespace DbContext.Configurations.OrdersConfigurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(oi => oi.Quantity)
            .IsRequired();

        builder.Property(oi => oi.PriceAtPurchase)
            .HasPrecision(10, 2);

        builder.HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(oi => oi.BranchProduct)
            .WithMany()
            .HasForeignKey(oi => oi.BranchProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
