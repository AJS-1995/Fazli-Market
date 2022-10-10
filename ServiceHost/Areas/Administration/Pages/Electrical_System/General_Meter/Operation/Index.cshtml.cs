using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.Electrical_System.General_Meter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.General_Meter.Operation
{
    public class IndexModel : PageModel
    {
        public int Id;
        public string Name;
        public List<OperationViewModel> Operations;
        private readonly IOperationApplication _operationApplication;
        private readonly IGeneralMeterApplication _generalMeterApplication;

        public IndexModel(IOperationApplication operationApplication, IGeneralMeterApplication generalMeterApplication)
        {
            _operationApplication = operationApplication;
            _generalMeterApplication = generalMeterApplication;
        }

        public void OnGet(int id)
        {
            Operations = _operationApplication.GetOperation().Where(x => x.Status == true && x.GeneralMeter_Id == id).ToList();
            var generalmeter = _generalMeterApplication.GetDetails(id);
            Name = generalmeter.Name;
            Id = generalmeter.Id;
        }
        public IActionResult OnGetCreate(int id)
        {
            var result = _generalMeterApplication.GetDetails(id);
            var command = new OperationCreate
            {
                GeneralMeter_Id = id,
                GeneralMeter = result.Name,
            };
            Id = id;
            return Partial("./Create", command);
        }
        public IActionResult OnPostCreate(OperationCreate command)
        {
            _operationApplication.Create(command);
            return RedirectToPage("./Index", new { id = command.GeneralMeter_Id });
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _operationApplication.GetDetails(id);
            result.GeneralMeters = _generalMeterApplication.GetGeneralMeter();
            Id = result.GeneralMeter_Id;
            return Partial("./Edit", result);
        }
        public IActionResult OnPostEdit(OperationEdit command)
        {
            _operationApplication.Edit(command);
            return RedirectToPage("./Index", new { id = command.GeneralMeter_Id });
        }
        public IActionResult OnGetRemoved(int id)
        {
            var command = new Removed
            {
                operations = _operationApplication.GetOperation().Where(x => x.Status == false && x.GeneralMeter_Id == id).ToList(),
                Id = id
            };
            return Partial("./Removed", command);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _operationApplication.Remove(id);
            var result = _operationApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.GeneralMeter_Id });
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _operationApplication.Activate(id);
            var result = _operationApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.GeneralMeter_Id });
        }

        //public IActionResult OnGetInvoice(int id)
        //{
        //    var result = _operationApplication.GetPhoto(id);
        //    return Partial("Invoice", result);
        //}
    }
}
