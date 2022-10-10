using Domin.Electrical_System.Box_MeterAgg.MeterAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class MPayMapping : IEntityTypeConfiguration<MPay>
    {
        public void Configure(EntityTypeBuilder<MPay> builder)
        {
            builder.ToTable("Tbl_MPays");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date_Pay).HasMaxLength(20);
            builder.Property(x => x.Photo).HasMaxLength(255);
        }
    }
}