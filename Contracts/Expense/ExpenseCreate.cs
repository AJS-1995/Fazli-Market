using _0_Framework.Application;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.PayBox;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Expense
{
    public class ExpenseCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; }
        public string Type { get; set; }
        public string N_Invoice { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public IFormFile Ph_Invoice { get; set; }
        public int UserId { get; set; }
        public int Id_Money { get; set; }
        public int PayBox_Id { get; set; }
        public List<MoneyViewModel> Moneys { get; set; }
        public List<ViewModel_PayBox> PayBoxs { get; set; }
    }
}