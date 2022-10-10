using Domin.PayBoxAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class PayBoxMapping : IEntityTypeConfiguration<PayBox>
    {
        public void Configure(EntityTypeBuilder<PayBox> builder)
        {
            builder.ToTable("Tbl_PayBoxs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }
}