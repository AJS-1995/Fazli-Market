using Domin.Electrical_System.General_MeterAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class GeneralMeterMapping : IEntityTypeConfiguration<GeneralMeter>
    {
        public void Configure(EntityTypeBuilder<GeneralMeter> builder)
        {
            builder.ToTable("Tbl_GeneralMeters");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Cod).HasMaxLength(25);
        }
    }
}