using Domin.Electrical_System.Box_MeterAgg.MeterAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class MOperationMapping : IEntityTypeConfiguration<MOperation>
    {
        public void Configure(EntityTypeBuilder<MOperation> builder)
        {
            builder.ToTable("Tbl_MOperations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date_Pay).HasMaxLength(20);
            builder.Property(x => x.Date_Rrad).HasMaxLength(20);
        }
    }
}