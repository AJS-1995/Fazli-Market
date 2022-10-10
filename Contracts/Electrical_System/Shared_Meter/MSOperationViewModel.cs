namespace AccountManagement.Application.Contracts.Electrical_System.Shared_Meter
{
    public class MSOperationViewModel
    {
        public int Id { get; set; }
        public int Meter_Id { get; set; }
        public string Meter { get; set; }
        public string Date_Rrad { get; set; }
        public string Date_Pay { get; set; }
        public int Grade_Past { get; set; }
        public int Grade_Now { get; set; }
        public int Grade { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal Rest { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
    }
}