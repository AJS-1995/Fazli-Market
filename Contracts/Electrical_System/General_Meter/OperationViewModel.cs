namespace AccountManagement.Application.Contracts.Electrical_System.General_Meter
{
    public class OperationViewModel
    {
        public int Id { get; set; }
        public int GeneralMeter_Id { get; set; }
        public string GeneralMeter { get; set; }
        public string Date_Rrad { get; set; }
        public string Date_Pay { get; set; }
        public int Grade_Past { get; set; }
        public int Grade_Now { get; set; }
        public decimal Amount { get; set; }
        public decimal Rest { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string Photo { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
    }
}
