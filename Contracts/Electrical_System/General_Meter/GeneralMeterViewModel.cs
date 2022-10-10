namespace AccountManagement.Application.Contracts.Electrical_System.General_Meter
{
    public class GeneralMeterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cod { get; set; }
        public int Grade { get; set; }
        public string Date { get; set; }
        public decimal Rest { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
    }
}
