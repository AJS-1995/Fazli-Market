namespace AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter
{
    public class MPayViewModel
    {
        public int Id { get; set; }
        public int Meter_Id { get; set; }
        public string Meter { get; set; }
        public int MOperation_Id { get; set; }
        public int PayBox_Id { get; set; }
        public string PayBox { get; set; }
        public string Date_Pay { get; set; }
        public string Date_Rrad { get; set; }
        public decimal Amount { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string Photo { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
    }
}