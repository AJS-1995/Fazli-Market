using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Person
{
    public interface IPersonApplication
    {
        OperationResult Create(PersonCreate command);
        OperationResult Edit(PersonEdit command);
        PersonEdit GetDetails(int id);
        List<PersonViewModel> GetPerson();
        void Remove(int id);
        void Activate(int id);
        OperationResult Total_Rest();
    }
}