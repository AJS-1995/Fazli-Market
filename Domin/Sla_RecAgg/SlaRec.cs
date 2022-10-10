using _0_Framework.Domain;

namespace Domin.Sla_RecAgg
{
    public class SlaRec : EntityBase<int>
    {
        public string Date { get; private set; }
        public string Description { get; private set; }
        public string By { get; private set; }
        public bool Type { get; private set; }
        public string N_Invoice { get; private set; }
        public decimal Amount { get; private set; }
        public int Money_Id { get; private set; }
        public int Person_Id { get; private set; }
        public int PayBox_Id { get; private set; }

        public SlaRec()
        {
        }

        public SlaRec(string date, string description, string by, bool type, string n_Invoice, decimal amount, int money_Id,
            int person_Id, int paybox_Id, int user_Id)
        {
            Date = date;
            Description = description;
            By = by;
            Type = type;
            N_Invoice = n_Invoice;
            Amount = amount;
            Money_Id = money_Id;
            Person_Id = person_Id;
            PayBox_Id = paybox_Id;
            User_Id = user_Id;
        }
        public void Edit(string date, string description, string by, bool type, string n_Invoice, decimal amount, int money_Id,
            int person_Id, int paybox_Id, int user_Id)
        {
            Date = date;
            Description = description;
            By = by;
            Type = type;
            N_Invoice = n_Invoice;
            Amount = amount;
            Money_Id = money_Id;
            Person_Id = person_Id;
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