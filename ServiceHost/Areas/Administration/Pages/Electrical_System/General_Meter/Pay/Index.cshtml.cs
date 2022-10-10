using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Electrical_System.General_Meter;
using AccountManagement.Application.Contracts.PayBox;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.General_Meter.Operation.Pay
{
    public class IndexModel : PageModel
    {
        public int Id;
        public string Name;
        public List<PayViewModel> Pays;
        private readonly IPayApplication _payApplication;
        private readonly IGeneralMeterApplication _generalMeterApplication;
        private readonly IOperationApplication _OperationApplication;
        private readonly IPayBoxApplication _payBoxApplication;
        public IndexModel(IPayApplication payApplication, IOperationApplication operationApplication, IPayBoxApplication payBoxApplication, IGeneralMeterApplication generalMeterApplication)
        {
            _payApplication = payApplication;
            _OperationApplication = operationApplication;
            _payBoxApplication = payBoxApplication;
            _generalMeterApplication = generalMeterApplication;
        }
        public void OnGet(int id)
        {
            Pays = _payApplication.GetPay().Where(x => x.Status == true && x.GeneralMeter_Id == id).ToList();
            var generalmeter = _generalMeterApplication.GetDetails(id);
            Name = generalmeter.Name;
            Id = generalmeter.Id;
        }
        public IActionResult OnGetCreate(int id)
        {
            var result = _generalMeterApplication.GetDetails(id);
            var command = new PayCreate
            {
                GeneralMeter_Id = id,
                GeneralMeter = result.Name,
                Operations = _OperationApplication.GetOperation(),
                PayBoxes = _payBoxApplication.GetPayBox(),
            };
            Id = id;
            return Partial("./Create", command);
        }
        public IActionResult OnPostCreate(PayCreate command)
        {
            _payApplication.Create(command);
            return RedirectToPage("./Index", new { id = command.GeneralMeter_Id });
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _payApplication.GetDetails(id);
            result.Generals = _generalMeterApplication.GetGeneralMeter();
            result.Operations = _OperationApplication.GetOperation();
            result.PayBoxes = _payBoxApplication.GetPayBox();
            Id = result.GeneralMeter_Id;
            return Partial("./Edit", result);
        }
        public IActionResult OnPostEdit(PayEdit command)
        {
            _payApplication.Edit(command);
            return RedirectToPage("./Index", new { id = command.GeneralMeter_Id });
        }
        public IActionResult OnGetRemoved(int id)
        {
            var command = new Removed
            {
                pays = _payApplication.GetPay().Where(x => x.Status == false && x.GeneralMeter_Id == id).ToList(),
                Id = id
            };
            return Partial("./Removed", command);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _payApplication.Remove(id);
            var result = _payApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.GeneralMeter_Id });
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _payApplication.Activate(id);
            var result = _payApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.GeneralMeter_Id });
        }
    }
}