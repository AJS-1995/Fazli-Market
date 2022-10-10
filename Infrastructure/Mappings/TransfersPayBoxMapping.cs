using Domin.PayBoxAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class TransfersPayBoxMapping : IEntityTypeConfiguration<TransfersPayBox>
    {
        public void Configure(EntityTypeBuilder<TransfersPayBox> builder)
        {
            builder.ToTable("Tbl_TransfersPayBoxs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.By).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Date).HasMaxLength(20);
        }
    }
}