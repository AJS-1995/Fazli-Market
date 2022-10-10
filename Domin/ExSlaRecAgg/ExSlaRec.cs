using _0_Framework.Domain;

namespace Domin.ExSlaRecAgg
{
    public class ExSlaRec : EntityBase<int>
    {
        public string Date { get; private set; }
        public string Description { get; private set; }
        public string By { get; private set; }
        public bool Type { get; private set; }
        public decimal Amount { get; private set; }
        public int Money_Id { get; private set; }
        public int Employee_Id { get; private set; }
        public int PayBox_Id { get; private set; }

        public ExSlaRec()
        {
        }

        public ExSlaRec(string date, string description, string by, bool type, decimal amount, int money_Id,
            int employee_Id, int paybox_Id, int user_Id)
        {
            Date = date;
            Description = description;
            By = by;
            Type = type;
            Amount = amount;
            Money_Id = money_Id;
            Employee_Id = employee_Id;
            PayBox_Id = paybox_Id;
            User_Id = user_Id;
        }
        public void Edit(string date, string description, string by, bool type, decimal amount, int money_Id,
            int employee_Id, int paybox_Id, int user_Id)
        {
            Date = date;
            Description = description;
            By = by;
            Type = type;
            Amount = amount;
            Money_Id = money_Id;
            Employee_Id = employee_Id;
            PayBox_Id = paybox_Id;
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