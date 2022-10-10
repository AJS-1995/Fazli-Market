namespace _01_Fazli_MarketQuery.Contracts.Users
{
    public class UserQueryModel
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string ProfilePhoto { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
    }
}