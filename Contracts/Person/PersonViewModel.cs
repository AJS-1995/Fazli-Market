namespace AccountManagement.Application.Contracts.Person
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Money_Id { get; set; }
        public string Money { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
        public decimal Rest { get; set; }
    }
}