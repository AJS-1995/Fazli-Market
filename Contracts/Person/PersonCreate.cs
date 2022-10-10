using _0_Framework.Application;
using AccountManagement.Application.Contracts.Money;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Person
{
    public class PersonCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Money_Id { get; set; }
        public List<MoneyViewModel> Moneys { get; set; }
    }
}