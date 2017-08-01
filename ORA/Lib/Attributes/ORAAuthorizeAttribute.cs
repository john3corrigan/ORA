using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Principal;

namespace Lib.Attributes
{
    public class ORAAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var authCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if(authCookie != null)
                {
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    var roles = ticket.UserData.Split('|');
                    var identity = new GenericIdentity(ticket.Name);
                    httpContext.User = new GenericPrincipal(identity, roles);
                }
            }
            return base.AuthorizeCore(httpContext);
        }
    }
}
