using _0_Framework.Domain;

namespace Domin.Expenses
{
    public class Expense : EntityBase<int>
    {
        public string Description { get; private set; }
        public string Type { get; private set; }
        public string N_Invoice { get; private set; }
        public decimal Amount { get; private set; }
        public string Date { get; private set; }
        public string Ph_Invoice { get; private set; }
        public int Id_Money { get; private set; }
        public int PayBox_Id { get; private set; }

        public Expense()
        {
        }

        public Expense(string description, string type, string n_Invoice, decimal amount, string date,
            string ph_invoice, int id_Money, int paybox_Id, int user_Id)
        {
            Description = description;
            Type = type;
            N_Invoice = n_Invoice;
            Amount = amount;
            Date = date;
            Id_Money = id_Money;
            PayBox_Id = paybox_Id;
            Ph_Invoice = ph_invoice;
            User_Id = user_Id;
        }
        public void Edit(string description, string type, string n_Invoice, decimal amount, string date,
            string ph_invoice, int id_Money, int paybox_Id, int user_Id)
        {
            Description = description;
            Type = type;
            N_Invoice = n_Invoice;
            Amount = amount;
            Date = date;
            Id_Money = id_Money;
            PayBox_Id = paybox_Id;

            if (!string.IsNullOrWhiteSpace(ph_invoice))
                Ph_Invoice = ph_invoice;

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