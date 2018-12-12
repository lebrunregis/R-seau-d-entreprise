using Model.Client.Data;
using Model.Client.Service;
using System;
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
            string teamId = httpContext.Request.Params.Get("teamId");
            string taskId = httpContext.Request.Params.Get("taskId");
            Task Task;
            IEnumerable<Employee> Team = null;
            try
            {
                if (!(taskId is null))
                {
                    Task = TaskService.Get(int.Parse(taskId), SessionUser.GetUser().Id);
                    if (Task.TeamId is null)
                    {
                        accessAllowed = true;
                    }
                    else
                    {
                        Team = TeamService.GetAllEmployeesForTeam((int)Task.TeamId);
                    }

                }
                else
                if (!(teamId is null))
                {
                    Team = TeamService.GetAllEmployeesForTeam(int.Parse(teamId));
                }

                var Result = from Employee in Team
                             where Employee.Employee_Id == SessionUser.GetUser().Id
                             select Employee;

                if (Result.Count() == 1)
                {
                    accessAllowed = true;
                }
            }

            catch (Exception ex)
            {
                throw ex;
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