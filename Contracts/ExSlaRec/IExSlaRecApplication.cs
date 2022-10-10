using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.ExSlaRec
{
    public interface IExSlaRecApplication
    {
        OperationResult Create(ExSlaRecCreate command);
        OperationResult Edit(ExSlaRecEdit command);
        ExSlaRecEdit GetDetails(int id);
        List<ExSlaRecViewModel> GetViewModel();
        void Remove(int id);
        void Activate(int id);
    }
}