using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.RoleAgg;
using Application;
using AccountManagement.Application.Contracts.Expense;
using AccountManagement.Application.Contracts.Inventory;
using AccountManagement.Application.Contracts.Person;
using Contracts.Role;
using Domin.AccountAgg;
using Domin.Expenses;
using Domin.InventoryAgg;
using Domin.Moneys;
using Domin.PersonAgg;
using Domin.ShopAgg;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.Shop;
using Domin.EmployeeAgg;
using AccountManagement.Application.Contracts.Employee;
using _01_Fazli_MarketQuery.Contracts.Users;
using _01_Fazli_MarketQuery.Query;
using AccountManagement.Application.Contracts.In_Out_Inventory;
using Domin.In_Out_InventoryAgg;
using Domin.Shop_For_RentAgg;
using AccountManagement.Application.Contracts.Locations;
using Domin.Locations;
using Domin.ReceiptRentAgg;
using AccountManagement.Application.Contracts.ReceiptRent;
using Domin.PayBoxAgg;
using AccountManagement.Application.Contracts.PayBox;
using Domin.Sla_RecAgg;
using AccountManagement.Application.Contracts.Sla_Rec;
using AccountManagement.Application.Contracts.Rent;
using Domin.RentAgg;
using Domin.ExSlaRecAgg;
using AccountManagement.Application.Contracts.ExSlaRec;
using Domin.SalaryAgg;
using AccountManagement.Application.Contracts.Salary;
using _01_Fazli_MarketQuery.Contracts.PayBoxs;
using AccountManagement.Application.Contracts.Electrical_System.General_Meter;
using Domin.Electrical_System.General_MeterAgg;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using Domin.Electrical_System.Box_MeterAgg;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using Domin.Electrical_System.Box_MeterAgg.MeterAgg;
using Domin.SoldAgg;
using AccountManagement.Application.Contracts.Electrical_System.Shared_Meter;
using Domin.Electrical_System.Shared_MeterAgg;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using AccountManagement.Application.Contracts.Sold;

namespace Configuration
{
    public class ManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IAccountApplication, AccountApplication>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddTransient<IShop_Application, Shop_Application>();
            services.AddTransient<IShop_Repository, Shop_Repository>();

            services.AddTransient<IMoneyApplication, MoneyApplication>();
            services.AddTransient<IMoneyRepository, MoneyRepository>();

            services.AddTransient<IExpenseApplication, ExpenseApplication>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();

            services.AddTransient<IPersonApplication, PersonApplication>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddTransient<IInventoryApplication, InventoryApplication>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();

            services.AddTransient<IEmployeeApplication, EmployeeApplication>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IIn_Out_InventoryApplication, In_Out_InventoryApplication>();
            services.AddTransient<IIn_Out_InventoryRepository, In_Out_InventoryRepository>();

            services.AddTransient<IShop_For_RentApplication, Shop_For_RentApplication>();
            services.AddTransient<IShopForRentRepository, ShopForRent_Repository>();

            services.AddTransient<ISoldApplication, SoldApplication>();
            services.AddTransient<ISoldRepository, SoldRepository>();

            services.AddTransient<ILocation_Application, Location_Application>();
            services.AddTransient<ILocation_Repository, Location_Repository>();

            services.AddTransient<IReceiptRentApplication, ReceiptRentApplication>();
            services.AddTransient<IReceiptRentRepository, ReceiptRentRepository>();

            services.AddTransient<IPayBoxApplication, PayBoxApplication>();
            services.AddTransient<IPayBoxRepository, PayBoxRepository>();

            services.AddTransient<ITransfersPayBoxApplication, TransfersPayBoxApplication>();
            services.AddTransient<ITransfersPayBoxRepository, TransfersPayBoxRepository>();

            services.AddTransient<ISla_RecApplication, Sla_RecApplication>();
            services.AddTransient<ISla_RecRepository, Sla_RecRepository>();

            services.AddTransient<IRentApplication, RentApplication>();
            services.AddTransient<IRentRepository, RentRepository>();

            services.AddTransient<IExSlaRecApplication, ExSlaRecApplication>();
            services.AddTransient<IExSlaRecRepository, ExSlaRecRepository>();

            services.AddTransient<IOperationApplication, OperationApplication>();
            services.AddTransient<IOperationRepository, OperationRepository>();

            services.AddTransient<IGeneralMeterApplication, GeneralMeterApplication>();
            services.AddTransient<IGeneralMeterRepository, GeneralMeterRepository>();

            services.AddTransient<ISalaryApplication, SalaryApplication>();
            services.AddTransient<ISalaryRepository, SalaryRepository>();

            services.AddTransient<IBoxMeterApplication, BoxMeterApplication>();
            services.AddTransient<IBoxMeterRepository, BoxMeterRepository>();

            services.AddTransient<IMeterApplication, MeterApplication>();
            services.AddTransient<IMeterRepository, MeterRepository>();

            services.AddTransient<IMOperationApplication, MOperationApplication>();
            services.AddTransient<IMOperationRepository, MOperationRepository>();

            services.AddTransient<IPayApplication, PayApplication>();
            services.AddTransient<IPayRepository, PayRepository>();

            services.AddTransient<IMPayApplication, MPayApplication>();
            services.AddTransient<IMPayRepository, MPayRepository>();

            services.AddTransient<IShared_MeterApplication, Shared_MeterApplication>();
            services.AddTransient<ISharedMeterRepository, Shared_MeterRepository>();

            services.AddTransient<IMSOperationApplication, MSOperationApplication>();
            services.AddTransient<IMSOperationRepository, MSOperationRepository>();

            services.AddTransient<IUserQueryModel, UserQuery>();
            services.AddTransient<IPayBox, PayBoxQuery>();

            services.AddDbContext<FM_Context>(x => x.UseSqlServer(connectionString));
        }
    }
}