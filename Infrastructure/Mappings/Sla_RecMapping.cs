using Domin.Sla_RecAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountMangement.Infrastructure.EFCore.Mappings
{
    public class Sla_RecMapping : IEntityTypeConfiguration<SlaRec>
    {
        public void Configure(EntityTypeBuilder<SlaRec> builder)
        {
            builder.ToTable("Tbl_Sla_Recs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.By).HasMaxLength(255);
            builder.Property(x => x.N_Invoice).HasMaxLength(255);
        }
    }
}