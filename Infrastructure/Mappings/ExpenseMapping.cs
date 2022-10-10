using Domin.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class ExpenseMapping : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Tbl_Expense");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.N_Invoice).HasMaxLength(255);
            builder.Property(x => x.Type).HasMaxLength(255);
            builder.Property(x => x.Date).HasMaxLength(20);
            builder.Property(x => x.Ph_Invoice).HasMaxLength(500);
        }
    }
}