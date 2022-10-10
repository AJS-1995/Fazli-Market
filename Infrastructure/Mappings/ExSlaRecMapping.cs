using Domin.ExSlaRecAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountMangement.Infrastructure.EFCore.Mappings
{
    public class ExSlaRecMapping : IEntityTypeConfiguration<ExSlaRec>
    {
        public void Configure(EntityTypeBuilder<ExSlaRec> builder)
        {
            builder.ToTable("Tbl_ExSlaRecs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.By).HasMaxLength(255);
        }
    }
}