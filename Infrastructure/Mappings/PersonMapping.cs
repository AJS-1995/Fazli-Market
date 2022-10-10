using Domin.PersonAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Tbl_Persons");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Company).HasMaxLength(255);
            builder.Property(x => x.Phone).HasMaxLength(25);
            builder.Property(x => x.Address).HasMaxLength(225);
        }
    }
}
