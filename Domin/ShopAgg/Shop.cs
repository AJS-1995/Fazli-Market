using _0_Framework.Domain;

namespace Domin.ShopAgg
{
    public class Shop : EntityBase<int>
    {
        public bool Sold { get; private set; }
        public int Location_Id { get; private set; }
        public string Name { get; private set; }
        public bool Rent { get; private set; }
        public int Id_Shopkeeper { get; private set; }
        public string Start_Date { get; private set; }
        public string End_Date { get; private set; }
        public string Date { get; private set; }
        public bool Meter { get; private set; }
        public decimal Rest { get; private set; }

        public Shop(int location_Id, string name, int user_Id)
        {
            Sold = false;
            Location_Id = location_Id;
            Name = name;
            Rent = false;
            User_Id = user_Id;
        }
        public Shop(int location_Id, string name, int user_Id, bool sold)
        {
            Sold = sold;
            Location_Id = location_Id;
            Name = name;
            User_Id = user_Id;
        }
        public void Edit(int location_Id, string name, int user_Id, bool sold)
        {
            Sold = sold;
            Location_Id = location_Id;
            Name = name;
            User_Id = user_Id;
        }
        public void Edit(int location_Id, string name, int user_Id)
        {
            Sold = false;
            Location_Id = location_Id;
            Name = name;
            User_Id = user_Id;
        }

        public void Edit(bool rent , int forrent)
        {
            Rent = rent;
            Id_Shopkeeper = forrent;
        }
        public void Edit(int forsold)
        {
            Id_Shopkeeper = forsold;
        }
        public void Edit(string date)
        {
            Date = date;
        }
        public void Edit(decimal rest)
        {
            Rest = rest;
        }
        public void Edit(bool meter)
        {
            Meter = meter;
        }
        public void Full(string start_date)
        {
            Start_Date = start_date;
            Date = start_date;
        }
        public void Empty(string end_date)
        {
            End_Date = end_date;
        }

        public void Remove()
        {
            Status = false;
        }
        public void Activate()
        {
            Status = true;
        }
        public void ShopSold()
        {
            Sold = true;
        }
        public void ShopRent()
        {
            Sold = false;
        }
    }
}