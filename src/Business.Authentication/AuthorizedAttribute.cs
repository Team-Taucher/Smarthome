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
            var isAuthorizationNeeded = controllerType.GetCustomAttribute<AuthorizedAttribute>() != null;

            if (isAuthorizationNeeded)
            {
                if (!context.HttpContext.Request.Cookies.ContainsKey("CookieKey"))
                {
                    Redirect(context, "/login");
                    return;
                }

                // Decode base64-cookie to the credentials
                var cookieRaw = context.HttpContext.Request.Cookies["CookieKey"];
                var cookieBytes = System.Convert.FromBase64String(cookieRaw);
                var cookieEncoded = System.Text.Encoding.UTF8.GetString(cookieBytes);
                var credentials = cookieEncoded.Split(", ");

                var cookieUser = new User
                {
                    Username = credentials[0],
                    Password = credentials[1]
                };

                // Search user in the repo with the matching credentials
                var userResult = _userRepository.FindUserByCredentials(cookieUser.Username, cookieUser.Password);

                if (userResult == null)
                {
                    Redirect(context, "/login");
                }
            }
        }

        /// <summary>
        /// Redirects the Browser to the given url
        /// </summary>
        /// <param name="context">Context of the Action-Executing</param>
        /// <param name="redirectUrl">Url to redirect to</param>
        private void Redirect(ActionExecutingContext context, string redirectUrl)
        {
            var baseUrl = context.HttpContext.Request.Host.ToUriComponent();
            context.HttpContext.Response.Redirect(baseUrl + redirectUrl);
        }
    }
}
