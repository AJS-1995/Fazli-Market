namespace AccountManagement.Application.Contracts.Shop
{
    public class Edit_Shop : Create_Shop
    {
        public int Id { get; set; }
        public int Id_Shopkeeper { get; set; }
        public string Location { get; set; }
    }
}