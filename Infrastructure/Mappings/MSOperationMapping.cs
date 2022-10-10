using Domin.Electrical_System.Shared_MeterAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class MSOperationMapping : IEntityTypeConfiguration<MSOperation>
    {
        public void Configure(EntityTypeBuilder<MSOperation> builder)
        {
            builder.ToTable("Tbl_MSOperations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date_Pay).HasMaxLength(20);
            builder.Property(x => x.Date_Rrad).HasMaxLength(20);
        }
    }
}