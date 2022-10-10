namespace AccountManagement.Application.Contracts.Electrical_System.Box_Meter
{
    public class BoxMeterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
    }
}