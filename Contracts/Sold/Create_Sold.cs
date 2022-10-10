using _0_Framework.Application;
using AccountManagement.Application.Contracts.Shop;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Sold
{
    public class Create_Sold
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public int Shop_Id { get; set; }
        public string LocationName { get; set; }
        public string ShopName { get; set; }
        public List<ViewModel_Shop> Shops { get; set; }
    }
}