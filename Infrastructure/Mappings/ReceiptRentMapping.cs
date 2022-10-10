using Domin.ReceiptRentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class ReceiptRentMapping : IEntityTypeConfiguration<ReceiptRent>
    {
        public void Configure(EntityTypeBuilder<ReceiptRent> builder)
        {
            builder.ToTable("Tbl_ReceiptRents");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.By).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Date).HasMaxLength(50);
            builder.Property(x => x.Years).HasMaxLength(50);
            builder.Property(x => x.Months).HasMaxLength(50);
        }
    }
}