using System.Collections.Generic;
using System.Linq;
using _01_Fazli_MarketQuery.Contracts.PayBoxs;
using AccountManagement.Application.Contracts.PayBox;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.PayBox
{
    public class IndexModel : PageModel
    {
        public List<ViewModel_PayBox> payboxs;
        private readonly IPayBox _payBox;
        private readonly IPayBoxApplication _payBoxApplication;
        public IndexModel(IPayBoxApplication payBoxApplication, IPayBox payBox)
        {
            _payBoxApplication = payBoxApplication;
            _payBox = payBox;
        }
        public void OnGet()
        {
            _payBox.Total_PayBox();
            payboxs = _payBoxApplication.GetPayBox().Where(x => x.Status == true).ToList();
        }
    }
}