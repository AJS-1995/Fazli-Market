using Domin.In_Out_InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class In_Out_InventoryMapping : IEntityTypeConfiguration<In_Out_Inventory>
    {
        public void Configure(EntityTypeBuilder<In_Out_Inventory> builder)
        {
            builder.ToTable("Tbl_In_Out_Inventorys");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Details).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.By).HasMaxLength(100);
            builder.Property(x => x.Type).HasMaxLength(10);
            builder.Property(x => x.Ph_Invoice).HasMaxLength(500);
        }
    }
}