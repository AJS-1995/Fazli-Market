using _0_Framework.Domain;

namespace Domin.ReceiptRentAgg
{
    public class ReceiptRent : EntityBase<int>
    {
        public string By { get; private set; }
        public int ForRent_Id { get; private set; }
        public int Shop_Id { get; private set; }
        public int PayBox_Id { get; private set; }
        public int Shop_Amount { get; private set; }
        public string Date { get; private set; }
        public int Years { get; private set; }
        public int Months { get; private set; }

        public ReceiptRent()
        {
        }

        public ReceiptRent(string by, int forRent_Id, int shop_Id, int paybox_Id, int shop_Amount, int user_Id, string date, int years, int months)
        {
            By = by;
            ForRent_Id = forRent_Id;
            Shop_Id = shop_Id;
            PayBox_Id = paybox_Id;
            Shop_Amount = shop_Amount;
            User_Id = user_Id;
            Date = date;
            Years = years;
            Months = months;
        }
        public void Edit(string by, int forRent_Id, int shop_Id, int paybox_Id, int shop_Amount, int user_Id, string date, int years, int months)
        {
            By = by;
            ForRent_Id = forRent_Id;
            Shop_Id = shop_Id;
            PayBox_Id = paybox_Id;
            Shop_Amount = shop_Amount;
            User_Id = user_Id;
            Date = date;
            Years = years;
            Months = months;
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