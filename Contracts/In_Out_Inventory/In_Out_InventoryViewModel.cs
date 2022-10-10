namespace AccountManagement.Application.Contracts.In_Out_Inventory
{
    public class In_Out_InventoryViewModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Details { get; set; }
        public string By { get; set; }
        public float Amount { get; set; }
        public decimal Sum { get; set; }
        public string Type { get; set; }
        public string Ph_Invoice { get; set; }
        public int MoneyId { get; set; }
        public string Money { get; set; }
        public int InventoryId { get; set; }
        public string Inventory { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
        public bool Status { get; set; }
        public string CreationDate { get; set; }
    }
}