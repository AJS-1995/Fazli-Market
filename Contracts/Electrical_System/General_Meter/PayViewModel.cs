namespace AccountManagement.Application.Contracts.Electrical_System.General_Meter
{
    public class PayViewModel
    {
        public int Id { get; set; }
        public int GeneralMeter_Id { get; set; }
        public int Operation_Id { get; set; }
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