using Domin.SoldAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class SoldMapping : IEntityTypeConfiguration<Sold>
    {
        public void Configure(EntityTypeBuilder<Sold> builder)
        {
            builder.ToTable("Tbl_Sold");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(255);
            builder.Property(x => x.Company).HasMaxLength(255);
            builder.Property(x => x.End_Date).HasMaxLength(20);
            builder.Property(x => x.Start_Date).HasMaxLength(20);
            builder.Property(x => x.Phone).HasMaxLength(20);
        }
    }
}