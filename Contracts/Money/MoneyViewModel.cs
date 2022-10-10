namespace AccountManagement.Application.Contracts.Money
{
    public class MoneyViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Symbol { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
    }
}