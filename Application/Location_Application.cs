using _0_Framework.Application;
using AccountManagement.Application.Contracts.Locations;
using Domin.Locations;
using System.Collections.Generic;

namespace Application
{
    public class Location_Application : ILocation_Application
    {
        private readonly ILocation_Repository _location_Repository;
        private readonly IAuthHelper ـauthHelper;
        public Location_Application(ILocation_Repository location_Repository, IAuthHelper ـauthHelper)
        {
            _location_Repository = location_Repository;
            this.ـauthHelper = ـauthHelper;
        }

        public void Activate(int id)
        {
            var result = _location_Repository.Get(id);
            result.Activate();
            _location_Repository.SaveChanges();
        }

        public OperationResult Create(Create_Location command)
        {
            var Operation = new OperationResult();
            if (_location_Repository.Exists(x => x.Name == command.Name))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                int userid = ـauthHelper.CurrentAccountId();
                var result = new Location(command.Name, userid);
                _location_Repository.Create(result);
                _location_Repository.SaveChanges();
                return Operation.Succedded();
            }
        }

        public OperationResult Edit(Edit_Location command)
        {
            var operation = new OperationResult();
            var result = _location_Repository.Get(command.Id);
            if (result == null)
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            else
            {
                if (_location_Repository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                {
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    int userid = ـauthHelper.CurrentAccountId();
                    result.Edit(command.Name, userid);
                    _location_Repository.SaveChanges();
                    return operation.Succedded();
                }
            }
        }

        public Edit_Location GetDetails(int id)
        {
            return _location_Repository.GetDetails(id);
        }

        public List<ViewModel_Location> GetViewModel()
        {
            return _location_Repository.GetViewModel();
        }

        public void Remove(int id)
        {
            var result = _location_Repository.Get(id);
            result.Remove();
            _location_Repository.SaveChanges();
        }
    }
}