namespace AccountManagement.Application.Contracts.Electrical_System.Shared_Meter
{
    public class Shared_MeterViewModel
    {
        public int Id { get; set; }
        public int BoxMeter_Id { get; set; }
        public string BoxMeter { get; set; }
        public string Name { get; set; }
        public string Cod { get; set; }
        public bool Use { get; set; }
        public decimal Rest { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
        public decimal Grade { get; set; }
    }
}