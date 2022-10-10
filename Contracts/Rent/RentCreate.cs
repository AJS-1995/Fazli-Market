namespace AccountManagement.Application.Contracts.Rent
{
    public class RentCreate
    {
        public int Shop_Id { get; set; }
        public string Location { get; set; }
        public string Shop { get; set; }
        public int Money_Id { get; set; }
        public string Money { get; set; }
        public int ForRent_Id { get; set; }
        public string ForRentName { get; set; }
        public string ForRentCompany { get; set; }
        public int Year { get; set; }
        public decimal Years { get; set; }
        public decimal Month_1 { get; set; }
        public decimal Month_2 { get; set; }
        public decimal Month_3 { get; set; }
        public decimal Month_4 { get; set; }
        public decimal Month_5 { get; set; }
        public decimal Month_6 { get; set; }
        public decimal Month_7 { get; set; }
        public decimal Month_8 { get; set; }
        public decimal Month_9 { get; set; }
        public decimal Month_10 { get; set; }
        public decimal Month_11 { get; set; }
        public decimal Month_12 { get; set; }
        public decimal Month { get; set; }
        public decimal Rent { get; set; }
    }
}