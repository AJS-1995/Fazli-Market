using Domin.Electrical_System.General_MeterAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class OperationMapping : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.ToTable("Tbl_Operations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date_Pay).HasMaxLength(20);
            builder.Property(x => x.Date_Rrad).HasMaxLength(20);
            builder.Property(x => x.Photo).HasMaxLength(255);
        }
    }
}