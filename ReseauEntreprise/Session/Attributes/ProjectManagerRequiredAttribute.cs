using Réseau_d_entreprise.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Model.Client.Data;
using Model.Client.Service;

namespace ReseauEntreprise.Session.Attributes
{
    public class ProjectManagerRequiredAttribute : AuthorizeAttribute
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool accessAllowed = false;
            string projectId = httpContext.Request.Params.Get("projectId");
            string teamId = httpContext.Request.Params.Get("teamId");
            int UserId = SessionUser.GetUser().Id;
            try
            {
                if (!(teamId is null))
                {
                    Team team = TeamService.GetTeamById(int.Parse(teamId));
                    Project project = ProjectService.GetProjectById(team.Project_Id);
                    if (project.ProjectManagerId == UserId)
                    {
                        accessAllowed = true;
                    }
                }else
                if (!(projectId is null))
                {
                    IEnumerable<Project> projects = SessionUser.GetUser().AuthorizedProjects;

                    foreach (Project project in projects)
                    {
                        if (project.Id == int.Parse(teamId) && UserId == project.ProjectManagerId)
                        {
                            accessAllowed = true;
                            break;
                        }
                    }
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