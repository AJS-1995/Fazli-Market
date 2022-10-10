using _0_Framework.Domain;

namespace Domin.Moneys
{
    public class Money : EntityBase<int>
    {
        public string Name { get; private set; }
        public string Country { get; private set; }
        public string Symbol { get; private set; }
        public Money(string name, string country, string symbol, int user_Id)
        {
            Name = name;
            Country = country;
            Symbol = symbol;
            User_Id = user_Id;
        }
        public void Edit(string name, string country, string symbol, int user_Id)
        {
            Name = name;
            Country = country;
            Symbol = symbol;
            User_Id = user_Id;
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