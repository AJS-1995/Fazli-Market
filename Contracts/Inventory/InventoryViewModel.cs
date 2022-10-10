namespace AccountManagement.Application.Contracts.Inventory
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
    }
}