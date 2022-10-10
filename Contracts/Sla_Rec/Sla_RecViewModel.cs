namespace AccountManagement.Application.Contracts.Sla_Rec
{
    public class Sla_RecViewModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string By { get; set; }
        public bool Type { get; set; }
        public string N_Invoice { get; set; }
        public decimal Amount { get; set; }
        public int Money_Id { get; set; }
        public string Money { get; set; }
        public int Person_Id { get; set; }
        public string Person { get; set; }
        public int PayBox_Id { get; set; }
        public string PayBox { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
    }
}