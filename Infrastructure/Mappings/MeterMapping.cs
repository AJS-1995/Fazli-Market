using Domin.Electrical_System.Box_MeterAgg.MeterAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountMangement.Infrastructure.EFCore.Mappings
{
    public class MeterMapping : IEntityTypeConfiguration<Meter>
    {
        public void Configure(EntityTypeBuilder<Meter> builder)
        {
            builder.ToTable("Tbl_Meters");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Cod).HasMaxLength(50);
        }
    }
}