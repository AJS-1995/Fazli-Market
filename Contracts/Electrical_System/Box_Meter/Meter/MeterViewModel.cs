namespace AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter
{
    public class MeterViewModel
    {
        public int Id { get; set; }
        public int BoxMeter_Id { get; set; }
        public string BoxMeter { get; set; }
        public string Name { get; set; }
        public string Cod { get; set; }
        public bool Use { get; set; }
        public int Shop_Id { get; set; }
        public string Shop { get; set; }
        public int Location_Id { get; set; }
        public string Location { get; set; }
        public decimal Rest { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
        public decimal Grade { get; set; }
    }
}