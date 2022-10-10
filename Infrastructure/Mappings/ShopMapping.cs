using Domin.ShopAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountMangement.Infrastructure.EFCore.Mappings
{
    public class ShopMapping : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.ToTable("Tbl_Shops");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Start_Date).HasMaxLength(25);
            builder.Property(x => x.End_Date).HasMaxLength(25);
            builder.Property(x => x.Date).HasMaxLength(25);
        }
    }
}