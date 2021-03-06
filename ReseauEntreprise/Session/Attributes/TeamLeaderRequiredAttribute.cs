﻿using Model.Client.Data;
using Model.Client.Service;
using System;
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
            string teamId = httpContext.Request.Params.Get("teamId");
            int UserId = SessionUser.GetUser().Id;

            try
            {
                if (!(teamId is null))
                {
                    int TeamId = int.Parse(teamId);
                    if (UserId == TeamService.GetTeamLeaderId(TeamId))
                    {
                        accessAllowed = true;
                    }
                    else
                    {
                        Team Team = TeamService.GetTeamById(TeamId);
                        if (UserId == ProjectService.GetProjectManagerId(Team.Project_Id))
                        {
                            accessAllowed = true;
                        }
                    }
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
                                       { "action", "AccessDenied" },
                                       { "controller", "Home" },
                                       { "Area", "Employee" }
                                       });
        }
    }
}