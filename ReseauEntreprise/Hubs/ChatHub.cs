using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Réseau_d_entreprise.Session;
using Réseau_d_entreprise.Session.Attributes;
using ReseauEntreprise.Session;

namespace SignalRChat
{
    [EmployeeRequired]
    public class ChatHub : Hub
    {
        public void Send(int id, string message)
        {
            Clients.All.addNewMessageToPage(id, message);
        }
    }
}