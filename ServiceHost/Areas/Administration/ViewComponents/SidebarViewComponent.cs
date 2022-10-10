using _0_Framework.Application;
using _01_Fazli_MarketQuery;
using _01_Fazli_MarketQuery.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Administration.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IUserQueryModel _userQueryModel;
        private readonly IAuthHelper _authHelper;
        public SidebarViewComponent(IAuthHelper authHelper, IUserQueryModel userQueryModel)
        {
            _authHelper = authHelper;
            _userQueryModel = userQueryModel;
        }
        public IViewComponentResult Invoke()
        {
            var userid = _authHelper.CurrentAccountInfo();
            var result = new SidebarModel
            {
                UsersQueryModel = _userQueryModel.GetUsers(userid.Id),
            };
            return View(result);
        }
    }
}