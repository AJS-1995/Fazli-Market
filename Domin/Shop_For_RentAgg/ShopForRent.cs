using _0_Framework.Domain;

namespace Domin.Shop_For_RentAgg
{
    public class ShopForRent : EntityBase<int>
    {
        public string Name { get; private set; }
        public string Company { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public string Id_Card { get; private set; }
        public string Id_Card_Scan { get; private set; }
        public string Line_Contract_Scan { get; private set; }
        public string Start_Date { get; private set; }
        public string End_Date { get; private set; }
        public decimal Rent { get; private set; }
        public decimal Rest { get; private set; }
        public int Money_Id { get; private set; }
        public int Shop_Id { get; private set; }

        public ShopForRent()
        {
        }

        public ShopForRent(string name, string company, string phone, string address, string id_Card,
            string id_Card_Scan, string line_Contract_Scan, string start_Date, string end_Date, decimal rent,
            int id_Money, int id_Shop, int user_Id)
        {
            Name = name;
            Company = company;
            Phone = phone;
            Address = address;
            Id_Card = id_Card;
            Id_Card_Scan = id_Card_Scan;
            Line_Contract_Scan = line_Contract_Scan;
            Start_Date = start_Date;
            End_Date = end_Date;
            Rent = rent;
            Money_Id = id_Money;
            Shop_Id = id_Shop;
            User_Id = user_Id;
        }
        public void Edit(string name, string company, string phone, string address, string id_Card, string id_Card_Scan,
            string line_Contract_Scan, string start_Date, string end_Date, decimal rent, int id_Money, int id_Shop, int user_Id)
        {
            Name = name;
            Company = company;
            Phone = phone;
            Address = address;
            Id_Card = id_Card;

            if (!string.IsNullOrWhiteSpace(id_Card_Scan))
                Id_Card_Scan = id_Card_Scan;

            if (!string.IsNullOrWhiteSpace(line_Contract_Scan))
                Line_Contract_Scan = line_Contract_Scan;

            Start_Date = start_Date;
            End_Date = end_Date;
            Rent = rent;
            Money_Id = id_Money;
            Shop_Id = id_Shop;
            User_Id = user_Id;
        }
        public void Edit(string end_Date, int user_Id)
        {
            End_Date = end_Date;
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