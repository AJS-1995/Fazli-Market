namespace AccountManagement.Application.Contracts.Shop
{
    public class ViewModel_Locations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Rent { get; set; }
        public bool Meter { get; set; }
        public bool Sold { get; set; }
    }
}