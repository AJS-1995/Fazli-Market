using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Money;
using AccountManagement.Application.Contracts.PayBox;
using AccountManagement.Application.Contracts.Person;
using AccountManagement.Application.Contracts.Sla_Rec;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.PersonAccounts
{
    public class DetailsModel : PageModel
    {
        public List<Sla_RecViewModel> Sla_Recs;
        public string name;
        public int Id;
        private readonly ISla_RecApplication _sla_RecApplication;
        private readonly IPersonApplication _personApplication;
        private readonly IPayBoxApplication _payBoxApplication;
        private readonly IMoneyApplication _moneyApplication;
        public DetailsModel(IMoneyApplication moneyApplication, IPayBoxApplication payBoxApplication, IPersonApplication personApplication, ISla_RecApplication sla_RecApplication)
        {
            _moneyApplication = moneyApplication;
            _payBoxApplication = payBoxApplication;
            _personApplication = personApplication;
            _sla_RecApplication = sla_RecApplication;
        }
        public void OnGet(int id)
        {
            _personApplication.Total_Rest();
            Sla_Recs = _sla_RecApplication.GetViewModel().Where(x => x.Status == true && x.Person_Id == id).ToList();
            var person = _personApplication.GetDetails(id);
            name = person.Name;
            Id = id;
        }
        public IActionResult OnGetCreate(int id)
        {
            var person = _personApplication.GetDetails(id);
            var commnd = new Sla_RecCreate()
            {
                Person_Id = id,
                Person = person.Name,
                Money_Id = person.Money_Id,
                PayBoxs = _payBoxApplication.GetPayBox().Where(x => x.Status == true && x.Money_Id == person.Money_Id).ToList(),
                Money = _moneyApplication.GetDetails(person.Money_Id).Name,
            };
            return Partial("./Create", commnd);
        }
        public IActionResult OnPostCreate(Sla_RecCreate command)
        {
            _sla_RecApplication.Create(command);
            return RedirectToPage("./Details", new {id = command.Person_Id });
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _sla_RecApplication.GetDetails(id);
            var person_id = _sla_RecApplication.GetDetails(id).Person_Id;
            var person = _personApplication.GetDetails(person_id);
            result.Person_Id = person_id;
            result.Person = person.Name;
            result.Money_Id = person.Money_Id;
            result.PayBoxs = _payBoxApplication.GetPayBox().Where(x => x.Status == true && x.Money_Id == person.Money_Id).ToList();
            result.Money = _moneyApplication.GetDetails(person.Money_Id).Name;
            result.Id = id;
            return Partial("./Edit", result);
        }
        public IActionResult OnPostEdit(Sla_RecEdit command)
        {
            _sla_RecApplication.Edit(command);
            var result = _sla_RecApplication.GetDetails(command.Id);
            return RedirectToPage("./Details", new { id = result.Person_Id });
        }
        public IActionResult OnGetRemoved(int id)
        {
            var commnd = new Sla_RecRemoved()
            {
                Sla_Recs = _sla_RecApplication.GetViewModel().Where(x => x.Status == false && x.Person_Id == id).ToList(),
            };
            return Partial("./Removed", commnd);
        }
        public IActionResult OnGetActivate(int id)
        {
            _sla_RecApplication.Activate(id);
            var result = _sla_RecApplication.GetDetails(id);
            return RedirectToPage("./Details", new { id = result.Person_Id });
        }
        public IActionResult OnGetRemove(int id)
        {
            _sla_RecApplication.Remove(id);
            var result = _sla_RecApplication.GetDetails(id);
            return RedirectToPage("./Details", new { id = result.Person_Id });
        }
    }
}