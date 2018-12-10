using Microsoft.AspNet.SignalR;
using Réseau_d_entreprise.Session;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReseauEntreprise.Session
{
    public class SessionUserProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
          return SessionUser.GetUser().Id.ToString();
        }
    }
}