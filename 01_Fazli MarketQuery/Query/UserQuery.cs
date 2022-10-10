using _0_Framework.Application;
using _01_Fazli_MarketQuery.Contracts.Users;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _01_Fazli_MarketQuery.Query
{
    public class UserQuery : IUserQueryModel
    {
        private readonly FM_Context _context;

        public UserQuery(FM_Context context)
        {
            _context = context;
        }
        public UserQueryModel GetUsers(int id)
        {
            var user = _context.Accounts.Include(x => x.Role).Select(x => new UserQueryModel
            {
                Id=x.Id,
                Fullname = x.Fullname,
                Username = x.Username,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                ProfilePhoto = x.ProfilePhoto,
                CreationDate = x.CreationDate.ToFarsi(),
                Status = x.Status,
                Role = x.Role.Name
            }).FirstOrDefault(x => x.Id == id);
            return user;
        }
    }
}