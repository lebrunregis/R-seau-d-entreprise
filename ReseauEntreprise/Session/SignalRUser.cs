using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Session
{
    public class SignalRUser
    {
        public int Id { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }
}