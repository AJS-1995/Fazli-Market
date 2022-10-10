namespace AccountManagement.Application.Contracts.PayBox
{
    public class ViewModel_PayBox
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rest { get; set; }
        public int Money_Id { get; set; }
        public string Money { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
    }
}