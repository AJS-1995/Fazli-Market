using Domin.Moneys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountMangement.Infrastructure.EFCore.Mappings
{
    public class MoneyMapping : IEntityTypeConfiguration<Money>
    {
        public void Configure(EntityTypeBuilder<Money> builder)
        {
            builder.ToTable("Tbl_Moneys");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(100);
            builder.Property(x => x.Symbol).HasMaxLength(15);
        }
    }
}