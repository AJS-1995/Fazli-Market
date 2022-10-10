namespace AccountManagement.Application.Contracts.Shop
{
    public class ViewModel_Shop
    {
        public int Id { get; set; }
        public bool Sold { get; set; }
        public int Location_Id { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
        public bool Rent { get; set; }
        public int Id_Shopkeeper { get; set; }
        public string ForRentName { get; set; }
        public string ForRentCompany { get; set; }
        public string ForRentRent { get; set; }
        public decimal Rents { get; set; }
        public string ForRentRest { get; set; }
        public string ForRentMoney { get; set; }
        public string ForRentMoney_Id { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public string Date { get; set; }
        public decimal Rest { get; set; }
    }
}