using Model.Client.Data;
using Model.Client.Service;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Réseau_d_entreprise.Session.Attributes
{
    public class TeamLeaderRequiredAttribute : AuthorizeAttribute
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool accessAllowed = false;
            string req = httpContext.Request.Url.Segments.Last();
            try
            {
                int.TryParse(req.ToString(), out int teamId);
                int teamLeader = (int)TeamService.GetTeamLeaderId(teamId);

                if (SessionUser.GetUser().Id == teamLeader)
                {
                    accessAllowed = true;
                }
            }
            catch
            {
                return false;
            }

            return accessAllowed;
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                                       {
                                       { "action", "Index" },
                                       { "controller", "Home" }
                                       });
        }
    }
}