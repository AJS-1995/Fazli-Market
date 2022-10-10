namespace AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter
{
    public class MeterCreate
    {
        public int BoxMeter_Id { get; set; }
        public string Name { get; set; }
        public string Cod { get; set; }
        public bool Use { get; set; }
        public int Shop_Id { get; set; }
        public decimal Rest { get; set; }
        public decimal Grade { get; set; }
    }
}