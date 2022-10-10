namespace AccountManagement.Application.Contracts.Expense
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string N_Invoice { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public string Ph_Invoice { get; set; }
        public int Id_Money { get; set; }
        public string Money { get; set; }
        public int PayBox_Id { get; set; }
        public string PayBox { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
        public bool Status { get; set; }
        public string CreationDate { get; set; }
    }
}