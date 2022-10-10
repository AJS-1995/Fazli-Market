using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Locations;
using System.Collections.Generic;

namespace Domin.Locations
{
    public interface ILocation_Repository : IRepository<int, Location>
    {
        List<ViewModel_Location> GetViewModel();
        Edit_Location GetDetails(int id);
    }
}