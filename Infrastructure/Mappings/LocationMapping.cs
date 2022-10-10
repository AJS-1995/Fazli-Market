using Domin.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountMangement.Infrastructure.EFCore.Mappings
{
    public class LocationMapping : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Tbl_Locations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}