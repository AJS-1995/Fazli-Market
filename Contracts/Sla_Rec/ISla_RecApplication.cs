using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Sla_Rec
{
    public interface ISla_RecApplication
    {
        OperationResult Create(Sla_RecCreate command);
        OperationResult Edit(Sla_RecEdit command);
        Sla_RecEdit GetDetails(int id);
        List<Sla_RecViewModel> GetViewModel();
        void Remove(int id);
        void Activate(int id);
    }
}