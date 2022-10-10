using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServiceHost
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {

        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }
    }
}