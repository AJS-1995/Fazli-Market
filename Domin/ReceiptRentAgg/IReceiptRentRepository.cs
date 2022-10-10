using _0_Framework.Domain;
using AccountManagement.Application.Contracts.ReceiptRent;
using System.Collections.Generic;

namespace Domin.ReceiptRentAgg
{
    public interface IReceiptRentRepository : IRepository<int, ReceiptRent>
    {
        List<ReceiptRentViewModel> GetReceiptRent();
        ReceiptRentEdit GetDetails(int id);
    }
}