using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LMSystem.Filters
{
    public class RequireLoginFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = context.RouteData.Values["controller"]?.ToString();
            if (string.Equals(controllerName, "Login", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var isApiRequest = context.HttpContext.Request.Path.StartsWithSegments("/api");

            if (isApiRequest && string.Equals(controllerName, "AuthApi", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var username = context.HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                context.Result = isApiRequest
                    ? new UnauthorizedResult()
                    : new RedirectToActionResult("Index", "Login", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
