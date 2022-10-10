using _0_Framework.Domain;
using Domin.AccountAgg;
using System.Collections.Generic;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role : EntityBase<int>
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; private set; }

        protected Role()
        {
        }
        public Role(string name, int user_Id)
        {
            Name = name;
            Accounts = new List<Account>();
            User_Id = user_Id;
        }
        public void Edit(string name, int user_Id)
        {
            Name = name;
            User_Id = user_Id;
        }
    }
}