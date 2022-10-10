using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.People.Persons
{
    public class IndexModel : PageModel
    {
        public List<PersonViewModel> persons;

        private readonly IPersonApplication _personApplication;
        private readonly IMoneyApplication _moneyApplication;
        public IndexModel(IPersonApplication personApplication, IMoneyApplication moneyApplication)
        {
            _personApplication = personApplication;
            _moneyApplication = moneyApplication;
        }
        public void OnGet()
        {
            persons = _personApplication.GetPerson().Where(x => x.Status == true).ToList();
        }
        public IActionResult OnGetCreate()
        {
            var commnd = new PersonCreate()
            {
                Moneys = _moneyApplication.GetMoney().Where(x => x.Status == true).ToList(),
            };
            return Partial("./Create", commnd);
        }
        public IActionResult OnPostCreate(PersonCreate command)
        {
            _personApplication.Create(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetEdit(int id)
        {
            var account = _personApplication.GetDetails(id);
            account.Moneys = _moneyApplication.GetMoney();
            return Partial("Edit", account);
        }
        public IActionResult OnPostEdit(PersonEdit command)
        {
            _personApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemoved()
        {
            var commnd = new Removed()
            {
                Persons = _personApplication.GetPerson().Where(x => x.Status == false).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _personApplication.Activate(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _personApplication.Remove(id);
            return RedirectToPage("./Index");
        }
    }
}