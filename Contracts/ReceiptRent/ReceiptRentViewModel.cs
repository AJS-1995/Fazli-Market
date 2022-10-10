namespace AccountManagement.Application.Contracts.ReceiptRent
{
    public class ReceiptRentViewModel
    {
        public int Id { get; set; }
        public string By { get; set; }
        public int ForRent_Id { get; set; }
        public int Shop_Id { get; set; }
        public string ForRentName { get; set; }
        public string ForRentCompany { get; set; }
        public string Shop { get; set; }
        public int Money_Id { get; set; }
        public string Money { get; set; }
        public int Location_Id { get; set; }
        public string Location { get; set; }
        public int PayBox_Id { get; set; }
        public string PayBox { get; set; }
        public int Shop_Amount { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
        public string Date { get; set; }
        public int Years { get; set; }
        public int Months { get; set; }
    }
}