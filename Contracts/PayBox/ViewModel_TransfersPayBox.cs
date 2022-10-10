namespace AccountManagement.Application.Contracts.PayBox
{
    public class ViewModel_TransfersPayBox
    {
        public int Id { get; set; }
        public int PayBoxIn_Id { get; set; }
        public string PayBoxIn { get; set; }
        public int PayBoxTo_Id { get; set; }
        public string PayBoxTo { get; set; }
        public string By { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public int Money_Id { get; set; }
        public string Money { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
    }
}