using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Sold
{
    public class Removed
    {
        public List<ViewModel_Sold> Solds { get; set; }
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string ShopName { get; set; }
    }
}