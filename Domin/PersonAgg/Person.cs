using _0_Framework.Domain;

namespace Domin.PersonAgg
{
    public class Person : EntityBase<int>
    {
        public string Name { get; private set; }
        public string Company { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public int Money_Id { get; private set; }
        public decimal Rest { get; private set; }

        public Person()
        {
        }

        public Person(string name, string company, string phone, string address, int money_id, int user_Id)
        {
            Name = name;
            Company = company;
            Phone = phone;
            Address = address;
            Money_Id = money_id;
            User_Id = user_Id;
        }
        public void Edit(string name, string company, string phone, string address, int money_id, int user_Id)
        {
            Name = name;
            Company = company;
            Phone = phone;
            Address = address;
            Money_Id = money_id;
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