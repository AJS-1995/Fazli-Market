using Domin.EmployeeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Tbl_Employees");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(25);
            builder.Property(x => x.Address).HasMaxLength(225);
        }
    }
}