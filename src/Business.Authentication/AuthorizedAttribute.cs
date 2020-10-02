using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace Gelp.SmartHome.Business.Authentication
{
    /// <summary>
    /// Attribute for set a content secured or authorized
    /// </summary>
    public class AuthorizedAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Gets executed before every API-Endpoint call and checks if the endpoint or assigned class has <see cref="AuthorizedAttribute"/>.
        /// Then, searches for a cookie with the credentials. These credentials will be Filters to find a user in the database.
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerType = context.Controller.GetType().GetTypeInfo();
            var isAuthorizationNeeded = controllerType.GetCustomAttribute<AuthorizedAttribute>() == null;

            if (isAuthorizationNeeded)
            {
                // TODO: Redirect to login
            }
            else
            {
                // TODO: Get cookie and search for credentials in the database
            }
        }
    }
}
