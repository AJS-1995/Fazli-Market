using AccountManagement.Domain.RoleAgg;
using AccountMangement.Infrastructure.EFCore.Mappings;
using Domin.AccountAgg;
using Domin.Electrical_System.Box_MeterAgg;
using Domin.Electrical_System.Box_MeterAgg.MeterAgg;
using Domin.Electrical_System.General_MeterAgg;
using Domin.Electrical_System.Shared_MeterAgg;
using Domin.EmployeeAgg;
using Domin.Expenses;
using Domin.ExSlaRecAgg;
using Domin.In_Out_InventoryAgg;
using Domin.InventoryAgg;
using Domin.Locations;
using Domin.Moneys;
using Domin.PayBoxAgg;
using Domin.PersonAgg;
using Domin.ReceiptRentAgg;
using Domin.RentAgg;
using Domin.SalaryAgg;
using Domin.Shop_For_RentAgg;
using Domin.ShopAgg;
using Domin.Sla_RecAgg;
using Domin.SoldAgg;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class FM_Context : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Money> Moneys { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Inventory> Inventorys { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<In_Out_Inventory> In_Out_Inventorys { get; set; }
        public DbSet<ShopForRent> Shop_For_Rents { get; set; }
        public DbSet<Sold> Solds { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ReceiptRent> ReceiptRents { get; set; }
        public DbSet<PayBox> PayBoxs { get; set; }
        public DbSet<TransfersPayBox> TransfersPayBoxs { get; set; }
        public DbSet<SlaRec> SlaRecs { get; set; }
        public DbSet<ExSlaRec> ExSlaRecs { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<GeneralMeter> GeneralMeters { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<BoxMeter> BoxMeters { get; set; }
        public DbSet<Meter> Meters { get; set; }
        public DbSet<MOperation> MOperations { get; set; }
        public DbSet<Pay> Pays { get; set; }
        public DbSet<MPay> MPays { get; set; }
        public DbSet<Shared_Meter> Shared_Meters { get; set; }
        public DbSet<MSOperation> MSOperations { get; set; }
        public FM_Context(DbContextOptions<FM_Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}