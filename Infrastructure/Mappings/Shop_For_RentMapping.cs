using Domin.Shop_For_RentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class Shop_For_RentMapping : IEntityTypeConfiguration<ShopForRent>
    {
        public void Configure(EntityTypeBuilder<ShopForRent> builder)
        {
            builder.ToTable("Tbl_ShopForRent");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(255);
            builder.Property(x => x.Company).HasMaxLength(255);
            builder.Property(x => x.End_Date).HasMaxLength(20);
            builder.Property(x => x.Start_Date).HasMaxLength(20);
            builder.Property(x => x.Id_Card).HasMaxLength(20);
            builder.Property(x => x.Id_Card_Scan).HasMaxLength(500);
            builder.Property(x => x.Line_Contract_Scan).HasMaxLength(500);
            builder.Property(x => x.Phone).HasMaxLength(20);
        }
    }
}