using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Rent
{
    public interface IRentApplication
    {
        OperationResult Create(RentCreate command);
        OperationResult Edit(RentEdit command);
        OperationResult Month1(RentEdit command);
        OperationResult Month2(RentEdit command);
        OperationResult Month3(RentEdit command);
        OperationResult Month4(RentEdit command);
        OperationResult Month5(RentEdit command);
        OperationResult Month6(RentEdit command);
        OperationResult Month7(RentEdit command);
        OperationResult Month8(RentEdit command);
        OperationResult Month9(RentEdit command);
        OperationResult Month10(RentEdit command);
        OperationResult Month11(RentEdit command);
        OperationResult Month12(RentEdit command);
        RentEdit GetDetails(int id);
        List<RentViewModel> GetViewModel();
        void Remove(int id);
        void Activate(int id);
    }
}