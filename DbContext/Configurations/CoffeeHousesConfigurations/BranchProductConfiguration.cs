using Core.DAL.Branches;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class BranchProductConfiguration : IEntityTypeConfiguration<BranchProduct>
{
    public void Configure(EntityTypeBuilder<BranchProduct> builder)
    {
        builder.Property(bp => bp.Price)
            .HasPrecision(10, 2);

        builder.HasOne(bp => bp.Branch)
            .WithMany(b => b.BranchProducts)
            .HasForeignKey(bp => bp.BranchId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
