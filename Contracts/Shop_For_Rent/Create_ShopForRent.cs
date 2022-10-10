using _0_Framework.Application;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.Shop;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Shop_For_Rent
{
    public class Create_ShopForRent
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Id_Card { get; set; }
        public IFormFile Id_Card_Scan { get; set; }
        public IFormFile Line_Contract_Scan { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public decimal Rent { get; set; }
        public int Money_Id { get; set; }
        public int Shop_Id { get; set; }
        public string LocationName { get; set; }
        public string ShopName { get; set; }
        public List<MoneyViewModel> Moneys { get; set; }
        public List<ViewModel_Shop> Shops { get; set; }
    }
}