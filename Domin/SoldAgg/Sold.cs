using _0_Framework.Domain;

namespace Domin.SoldAgg
{
    public class Sold : EntityBase<int>
    {
        public string Name { get; private set; }
        public string Company { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public string Start_Date { get; private set; }
        public string End_Date { get; private set; }
        public int Shop_Id { get; private set; }
        public Sold()
        {
        }
        public Sold(string name, string company, string phone, string address, string start_Date, string end_Date, int id_Shop, int user_Id)
        {
            Name = name;
            Company = company;
            Phone = phone;
            Address = address;
            Start_Date = start_Date;
            End_Date = end_Date;
            Shop_Id = id_Shop;
            User_Id = user_Id;
        }
        public void Edit(string name, string company, string phone, string address, string start_Date, string end_Date, int id_Shop, int user_Id)
        {
            Name = name;
            Company = company;
            Phone = phone;
            Address = address;
            Start_Date = start_Date;
            End_Date = end_Date;
            Shop_Id = id_Shop;
            User_Id = user_Id;
        }
        public void Edit(string end_Date, int user_Id)
        {
            End_Date = end_Date;
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