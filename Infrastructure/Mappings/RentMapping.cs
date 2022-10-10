using Domin.RentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountMangement.Infrastructure.EFCore.Mappings
{
    public class RentMapping : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable("Tbl_Rents");
            builder.HasKey(x => x.Id);
        }
    }
}