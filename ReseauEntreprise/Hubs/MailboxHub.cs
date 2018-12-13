using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ReseauEntreprise.Hubs
{
    public class MailboxHub : Hub

    {
        public static void Send(int id)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<MailboxHub>();
            hubContext.Clients.All.RefreshMessagesId(id);
        }
    }
}