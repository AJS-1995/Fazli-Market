using Domin.Electrical_System.General_MeterAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class PayMapping : IEntityTypeConfiguration<Pay>
    {
        public void Configure(EntityTypeBuilder<Pay> builder)
        {
            builder.ToTable("Tbl_Pays");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date_Pay).HasMaxLength(20);
            builder.Property(x => x.Photo).HasMaxLength(255);
        }
    }
}