using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using System.Collections.Generic;

namespace Contracts.Role
{
    public interface IRoleApplication
    {
        OperationResult Create(CreateRole command);
        OperationResult Edit(EditRole command);
        List<RoleViewModel> List();
        EditRole GetDetails(int id);
    }
}
