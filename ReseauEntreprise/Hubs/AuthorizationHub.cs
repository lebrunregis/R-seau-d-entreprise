using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Session;

namespace ReseauEntreprise.Hubs
{
    public class AuthorizationHub : Hub
    {
        private readonly static ConnectionMapper<string> _connections =
        new ConnectionMapper<string>();

        private static readonly ConcurrentDictionary<string, User> Users
    = new ConcurrentDictionary<string, User>();

        public override Task OnConnected()
        {
            string sessionId = HttpContext.Current.Session.SessionID;
            string connectionId = Context.ConnectionId;
            string userId = Context.User.Identity.Name;

            return base.OnConnected();
        }




        public void SendMessage(string msg)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<AuthorizationHub>();
            string userId = Context.User.Identity.Name;
            hubContext.Clients.All.foo(msg);
        }
    }
}