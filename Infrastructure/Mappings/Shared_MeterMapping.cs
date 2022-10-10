using Domin.Electrical_System.Shared_MeterAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountMangement.Infrastructure.EFCore.Mappings
{
    public class Shared_MeterMapping : IEntityTypeConfiguration<Shared_Meter>
    {
        public void Configure(EntityTypeBuilder<Shared_Meter> builder)
        {
            builder.ToTable("Tbl_Shared_Meters");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Cod).HasMaxLength(50);
        }
    }
}