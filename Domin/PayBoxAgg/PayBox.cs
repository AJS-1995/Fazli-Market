using _0_Framework.Domain;

namespace Domin.PayBoxAgg
{
    public class PayBox : EntityBase<int>
    {
        public string Name { get; private set; }
        public decimal Rest { get; private set; }
        public int Money_Id { get; private set; }

        public PayBox(string name, int money_Id, int user_Id)
        {
            Name = name;
            Money_Id = money_Id;
            User_Id = user_Id;
        }
        public void Edit(string name, decimal rest, int money_Id, int user_Id)
        {
            Name = name;
            Rest = rest;
            Money_Id = money_Id;
            User_Id = user_Id;
        }
        public void Edit(decimal rest)
        {
            Rest = rest;
        }
        public void Remove()
        {
            Status = false;
        }
        public void Activate()
        {
            Status = true;
        }
    }
}