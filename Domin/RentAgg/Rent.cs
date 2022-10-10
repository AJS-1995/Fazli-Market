namespace Domin.RentAgg
{
    public class Rent
    {
        public int Id { get; set; }
        public int Year { get; private set; }
        public decimal Month_1 { get; private set; }
        public decimal Month_2 { get; private set; }
        public decimal Month_3 { get; private set; }
        public decimal Month_4 { get; private set; }
        public decimal Month_5 { get; private set; }
        public decimal Month_6 { get; private set; }
        public decimal Month_7 { get; private set; }
        public decimal Month_8 { get; private set; }
        public decimal Month_9 { get; private set; }
        public decimal Month_10 { get; private set; }
        public decimal Month_11 { get; private set; }
        public decimal Month_12 { get; private set; }
        public int Shop_Id { get; private set; }
        public int Money_Id { get; private set; }
        public int ForRent_Id { get; private set; }
        public bool Status { get; private set; }

        public Rent(int year, decimal month_1, decimal month_2, decimal month_3, decimal month_4, decimal month_5,
            decimal month_6, decimal month_7, decimal month_8, decimal month_9, decimal month_10, decimal month_11,
            decimal month_12, int shop_Id, int money_Id, int forRent_Id)
        {
            Year = year;
            Month_1 = month_1;
            Month_2 = month_2;
            Month_3 = month_3;
            Month_4 = month_4;
            Month_5 = month_5;
            Month_6 = month_6;
            Month_7 = month_7;
            Month_8 = month_8;
            Month_9 = month_9;
            Month_10 = month_10;
            Month_11 = month_11;
            Month_12 = month_12;
            Shop_Id = shop_Id;
            Money_Id = money_Id;
            ForRent_Id = forRent_Id;
            Status = true;
        }
        public void Edit(int year, decimal month_1, decimal month_2, decimal month_3, decimal month_4, decimal month_5,
    decimal month_6, decimal month_7, decimal month_8, decimal month_9, decimal month_10, decimal month_11,
    decimal month_12, int shop_Id, int money_Id, int forRent_Id)
        {
            Year = year;
            Month_1 = month_1;
            Month_2 = month_2;
            Month_3 = month_3;
            Month_4 = month_4;
            Month_5 = month_5;
            Month_6 = month_6;
            Month_7 = month_7;
            Month_8 = month_8;
            Month_9 = month_9;
            Month_10 = month_10;
            Month_11 = month_11;
            Month_12 = month_12;
            Shop_Id = shop_Id;
            Money_Id = money_Id;
            ForRent_Id = forRent_Id;
            Status = true;
        }

        public void Month1(decimal month_1)
        {
            Month_1 = month_1;
        }

        public void Month2(decimal month_2)
        {
            Month_2 = month_2;
        }
        public void Month3(decimal month_3)
        {
            Month_3 = month_3;
        }
        public void Month4(decimal month_4)
        {
            Month_4 = month_4;
        }
        public void Month5(decimal month_5)
        {
            Month_5 = month_5;
        }
        public void Month6(decimal month_6)
        {
            Month_6 = month_6;
        }
        public void Month7(decimal month_7)
        {
            Month_7 = month_7;
        }
        public void Month8(decimal month_8)
        {
            Month_8 = month_8;
        }
        public void Month9(decimal month_9)
        {
            Month_9 = month_9;
        }
        public void Month10(decimal month_10)
        {
            Month_10 = month_10;
        }
        public void Month11(decimal month_11)
        {
            Month_11 = month_11;
        }
        public void Month12(decimal month_12)
        {
            Month_12 = month_12;
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