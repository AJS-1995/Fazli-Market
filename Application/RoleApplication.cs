using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using Contracts.Role;
using System.Collections.Generic;

namespace Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IAuthHelper ـauthHelper;
        public RoleApplication(IRoleRepository roleRepository, IAuthHelper ـauthHelper)
        {
            _roleRepository = roleRepository;
            this.ـauthHelper = ـauthHelper;
        }

        public OperationResult Create(CreateRole command)
        {
            var operation = new OperationResult();
            if (_roleRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            int userid = ـauthHelper.CurrentAccountId();
            var role = new Role(command.Name, userid);
            _roleRepository.Create(role);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditRole command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.Get(command.Id);
            if (role == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_roleRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            int userid = ـauthHelper.CurrentAccountId();
            role.Edit(command.Name, userid);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditRole GetDetails(int id)
        {
            return _roleRepository.GetDetails(id);
        }

        public List<RoleViewModel> List()
        {
            return _roleRepository.List();
        }
    }
}