using Model.Client.Data;
using Model.Client.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Réseau_d_entreprise.Session.Attributes
{
    public class TeamMemberRequiredAttribute : AuthorizeAttribute
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool accessAllowed = false;
            string req = httpContext.Request.Url.Segments.Last();
            try
            {
                IEnumerable<Employee> team = TeamService.GetAllEmployeesForTeam(int.Parse(req));
                
                    
                var result = from employee in team
                where employee.Employee_Id == SessionUser.GetUser().Id
                select employee;

                if (result.Count() ==1)
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