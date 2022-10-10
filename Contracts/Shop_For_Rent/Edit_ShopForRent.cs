namespace AccountManagement.Application.Contracts.Shop_For_Rent
{
    public class Edit_ShopForRent : Create_ShopForRent
    {
        public int Id { get; set; }
        public string Card_Scan { get; set; }
        public string Contract_Scan { get; set; }
        public string Money { get; set; }
        public decimal Rest { get; set; }
    }
}