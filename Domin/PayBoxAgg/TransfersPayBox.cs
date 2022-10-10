using _0_Framework.Domain;

namespace Domin.PayBoxAgg
{
    public class TransfersPayBox : EntityBase<int>
    {
        public int PayBoxIn_Id { get; private set; }
        public int PayBoxTo_Id { get; private set; }
        public string By { get; private set; }
        public decimal Amount { get; private set; }
        public string Date { get; private set; }
        public int Money_Id { get; private set; }

        public TransfersPayBox()
        {
        }

        public TransfersPayBox(int payBoxIn_Id, int payBoxTo_Id, string by, decimal amount, string date, int money_Id, int user_id)
        {
            PayBoxIn_Id = payBoxIn_Id;
            PayBoxTo_Id = payBoxTo_Id;
            By = by;
            Amount = amount;
            Date = date;
            Money_Id = money_Id;
            User_Id = user_id;
        }
        public void Edit(int payBoxIn_Id, int payBoxTo_Id, string by, decimal amount, string date, int money_Id, int user_id)
        {
            PayBoxIn_Id = payBoxIn_Id;
            PayBoxTo_Id = payBoxTo_Id;
            By = by;
            Amount = amount;
            Date = date;
            Money_Id = money_Id;
            User_Id = user_id;
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