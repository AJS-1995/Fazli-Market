using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter;
using AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter;
using AccountManagement.Application.Contracts.PayBox;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Electrical_System.Box_Meter.Meter.Operation.Pay
{
    public class IndexModel : PageModel
    {
        public string Name;
        public string Cod;
        public int Id;
        public List<MPayViewModel> MPays;
        private readonly IMPayApplication _mpayApplication;
        private readonly IMeterApplication _meterApplication;
        private readonly IMOperationApplication _mOperationApplication;
        private readonly IPayBoxApplication _payBoxApplication;
        public IndexModel(IMPayApplication mpayApplication, IMOperationApplication mOperationApplication, IPayBoxApplication payBoxApplication, IMeterApplication meterApplication)
        {
            _mpayApplication = mpayApplication;
            _mOperationApplication = mOperationApplication;
            _payBoxApplication = payBoxApplication;
            _meterApplication = meterApplication;
        }
        public void OnGet(int id)
        {
            MPays = _mpayApplication.GetMPay().Where(x => x.Status == true && x.Meter_Id == id).ToList();
            var meter = _meterApplication.GetDetails(id);
            Name = meter.Name;
            Cod = meter.Cod;
            Id = id;
        }
        public IActionResult OnGetEdit(int id)
        {
            var result = _mpayApplication.GetDetails(id);
            result.MOperations = _mOperationApplication.GetOperation().Where(x => x.Status == true && x.Meter_Id == result.Meter_Id).ToList();
            result.PayBoxes = _payBoxApplication.GetPayBox().Where(x => x.Status == true).ToList();
            result.Meter = _meterApplication.GetDetails(result.Meter_Id).Name;
            result.Meter_Id = _meterApplication.GetDetails(result.Meter_Id).Id;
            result.Cod = _meterApplication.GetDetails(result.Meter_Id).Cod;
            return Partial("./Edit", result);
        }
        public IActionResult OnGetCreate(int id)
        {
            var command = new MPayCreate
            {
                MOperations = _mOperationApplication.GetOperation().Where(x => x.Status == true && x.Meter_Id == id).ToList(),
                PayBoxes = _payBoxApplication.GetPayBox().Where(x => x.Status == true).ToList(),
                Meter_Id = id,
                Meter = _meterApplication.GetDetails(id).Name,
                Cod = _meterApplication.GetDetails(id).Cod,
                Date_Pay = DateTime.Now.ToFarsi(),
        };
            return Partial("./Create", command);
        }
        public IActionResult OnPostCreate(MPayCreate command)
        {
            _mpayApplication.Create(command);
            return RedirectToPage("./Index", new { id = command.Meter_Id });
        }
        public IActionResult OnPostEdit(MPayEdit command)
        {
            _mpayApplication.Edit(command);
            return RedirectToPage("./Index", new { id = command.Meter_Id });
        }
        public IActionResult OnGetRemoved(int id)
        {
            var command = new MeterRemoved()
            {
                MPays = _mpayApplication.GetMPay().Where(x => x.Status == false && x.Meter_Id == id).ToList(),
                Id = id,
            };
            return Partial("./Removed", command);
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _mpayApplication.Remove(id);
            var result = _mpayApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.Meter_Id });
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _mpayApplication.Activate(id);
            var result = _mpayApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.Meter_Id });
        }
    }
}