using Domin.Electrical_System.Box_MeterAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountMangement.Infrastructure.EFCore.Mappings
{
    public class BoxMeterMapping : IEntityTypeConfiguration<BoxMeter>
    {
        public void Configure(EntityTypeBuilder<BoxMeter> builder)
        {
            builder.ToTable("Tbl_BoxMeters");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}