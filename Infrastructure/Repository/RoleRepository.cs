using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using Contracts.Role;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RoleRepository : RepositoryBase<int, Role>, IRoleRepository
    {
        private readonly FM_Context _context;

        public RoleRepository(FM_Context accountContext) : base(accountContext)
        {
            _context = accountContext;
        }
        public EditRole GetDetails(int id)
        {
            var role = _context.Roles.Select(x => new EditRole
            {
                Id = x.Id,
                Name = x.Name,
            }).AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            return role;
        }
        public List<RoleViewModel> List()
        {
            var users = _context.Accounts.Select(x => new { x.Id, x.Username }).ToList();
            var query = _context.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item =>
                item.UserName = users.FirstOrDefault(x => x.Id == item.User_Id)?.Username);

            return result;
        }
    }
}