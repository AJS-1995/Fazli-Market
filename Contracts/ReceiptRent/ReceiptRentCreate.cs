using _0_Framework.Application;
using AccountManagement.Application.Contracts.PayBox;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.ReceiptRent
{
    public class ReceiptRentCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string By { get; set; }
        public int ForRent_Id { get; set; }
        public int Shop_Id { get; set; }
        public int PayBox_Id { get; set; }
        public int Shop_Amount { get; set; }
        public string Date { get; set; }
        public int Years { get; set; }
        public int Months { get; set; }
        public string Location { get; set; }
        public string Shop { get; set; }
        public string ForRentName { get; set; }
        public string ForRentCompany { get; set; }
        public decimal ForRentRest { get; set; }
        public decimal Rent { get; set; }
        public int Money_Id { get; set; }
        public string Money { get; set; }
        public List<ViewModel_PayBox> PayBoxs { get; set; }
    }
}