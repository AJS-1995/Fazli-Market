using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Person;
using System.Collections.Generic;

namespace Domin.PersonAgg
{
    public interface IPersonRepository : IRepository<int, Person>
    {
        List<PersonViewModel> GetPerson();
        PersonEdit GetDetails(int id);
    }
}