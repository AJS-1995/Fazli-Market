using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.ReceiptRent
{
    public interface IReceiptRentApplication
    {
        OperationResult Create(ReceiptRentCreate command);
        OperationResult Edit(ReceiptRentEdit command);
        ReceiptRentEdit GetDetails(int id);
        List<ReceiptRentViewModel> GetReceiptRent();
        void Remove(int id);
        void Activate(int id);
    }
}