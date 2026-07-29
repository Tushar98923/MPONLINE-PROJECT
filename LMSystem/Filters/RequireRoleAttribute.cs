using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LMSystem.Filters
{
    public class RequireRoleAttribute : Attribute, IActionFilter
    {
        private readonly string _role;

        public RequireRoleAttribute(string role)
        {
            _role = role;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var role = context.HttpContext.Session.GetString("Role");
            var isApiRequest = context.HttpContext.Request.Path.StartsWithSegments("/api");

            if (!string.Equals(role, _role, StringComparison.OrdinalIgnoreCase))
            {
                context.Result = isApiRequest
                    ? new ObjectResult(new { message = "Forbidden." }) { StatusCode = 403 }
                    : new RedirectToActionResult("AccessDenied", "Login", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
