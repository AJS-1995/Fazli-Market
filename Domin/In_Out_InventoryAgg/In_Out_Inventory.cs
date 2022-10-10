using _0_Framework.Domain;

namespace Domin.In_Out_InventoryAgg
{
    public class In_Out_Inventory : EntityBase<int>
    {
        public string Date { get; private set; }
        public string Details { get; private set; }
        public string By { get; private set; }
        public float Amount { get; private set; }
        public decimal Sum { get; private set; }
        public string Type { get; private set; }
        public string Ph_Invoice { get; private set; }
        public int MoneyId { get; private set; }
        public int InventoryId { get; private set; }

        public In_Out_Inventory()
        {
        }
        public In_Out_Inventory(string date, string details, string by, float amount, decimal sum, string type,
            string ph_invoice,int moneyId, int inventoryId,int user_Id)
        {
            Date = date;
            Details = details;
            By = by;
            Amount = amount;
            Sum = sum;
            MoneyId = moneyId;
            InventoryId = inventoryId;
            Type = type;
            Ph_Invoice = ph_invoice;
            User_Id = user_Id;
        }
        public void Edit(string date, string details, string by, float amount, decimal sum, string type, string ph_invoice,
            int moneyId, int inventoryId, int user_Id)
        {
            Date = date;
            Details = details;
            By = by;
            Amount = amount;
            Sum = sum;
            MoneyId = moneyId;
            InventoryId = inventoryId;
            Type = type;
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