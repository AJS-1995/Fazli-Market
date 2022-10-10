using System.Collections.Generic;
using System.Linq;
using AccountManagement.Application.Contracts.ReceiptRent;
using AccountManagement.Application.Contracts.Shop;
using AccountManagement.Application.Contracts.Shop_For_Rent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.PeoplesAccounts.ShopkeeperAccounts.ReceiptRent
{
    public class IndexModel : PageModel
    {
        public List<ReceiptRentViewModel> receiptRents;
        public string Name;
        public string Company;
        public int Id;
        private readonly IReceiptRentApplication _receiptRentApplication;
        private readonly IShop_For_RentApplication _shop_For_RentApplication;
        private readonly IShop_Application _shop_Application;
        public IndexModel(IReceiptRentApplication receiptRentApplication, IShop_For_RentApplication shop_For_RentApplication,
            IShop_Application shop_Application)
        {
            _receiptRentApplication = receiptRentApplication;
            _shop_For_RentApplication = shop_For_RentApplication;
            _shop_Application = shop_Application;
        }
        public void OnGet(int id)
        {
            _shop_Application.Rest();
            _shop_For_RentApplication.Total_Rest();
            receiptRents = _receiptRentApplication.GetReceiptRent().Where(x => x.Status == true && x.ForRent_Id == id).ToList();
            Name = _shop_For_RentApplication.GetDetails(id).Name;
            Company = _shop_For_RentApplication.GetDetails(id).Company;
            Id = id;
        }
        public IActionResult OnGetRemoved(int id)
        {
            var commnd = new Removed()
            {
                Receipts = _receiptRentApplication.GetReceiptRent().Where(x => x.Status == false && x.ForRent_Id == id).ToList(),
                Id = id,
            };
            Id = id;
            return Partial("./Removed", commnd);
        }
        public IActionResult OnGetActivate(int id)
        {
            _receiptRentApplication.Activate(id);
            var result = _receiptRentApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.ForRent_Id });
        }
        public IActionResult OnGetRemove(int id)
        {
            _receiptRentApplication.Remove(id);
            var result = _receiptRentApplication.GetDetails(id);
            return RedirectToPage("./Index", new { id = result.ForRent_Id });
        }
    }
}