using Gelp.SmartHome.Common.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using Gelp.SmartHome.Communication.Database;

namespace Gelp.SmartHome.Business.Authentication
{
    /// <summary>
    /// Attribute for set a content secured or authorized
    /// </summary>
    public class AuthorizedAttribute : ActionFilterAttribute
    {
        private readonly UserRepository _userRepository = new UserRepository();
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
                var cookie = context.HttpContext.Request.Cookies["CookieKey"];

                // TODO: Split cookie up into username and password
                var cookieUser = new User();

                var userResult = _userRepository.FindUserByCredentials(cookieUser.Username, cookieUser.Password);

                if (userResult == null)
                {
                    // TODO: Redirect to login
                }
            }
        }
    }
}
