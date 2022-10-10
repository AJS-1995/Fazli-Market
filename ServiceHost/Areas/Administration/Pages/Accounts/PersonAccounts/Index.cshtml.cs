using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Person;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.PersonAccounts
{
    public class IndexModel : PageModel
    {
        public List<PersonViewModel> Persons;
        private readonly IPersonApplication _personApplication;
        public IndexModel(IPersonApplication personApplication)
        {
            _personApplication = personApplication;
        }
        public void OnGet()
        {
            _personApplication.Total_Rest();
            Persons = _personApplication.GetPerson().Where(x => x.Status == true).ToList();
        }
    }
}