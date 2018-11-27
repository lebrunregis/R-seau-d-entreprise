using Model.Client.Data;
using Model.Client.Mapper;
using G = Model.Global.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Service
{
    public class EventService
    {

        public static int Create(Event e,int UserId)
        {

            return 
        }

        public static bool Edit(Event e, int UserId)
        {

            return 
        }

        public static bool Delete(Event e, int UserId)
        {

            return
        }
        
        public static Event Get(int id)
        {

            return 
        }

        public static IEnumerable<Event> GetAll()
        {

            return 
        }

        public static IEnumerable<Event> GetAllActive()
        {

            return 
        }

        public static IEnumerable<Event> GetAllActiveForUser(int UserId)
        {

            return 
        }

        public static bool Participate(int EventId, int EmpId)
        {

            return 
        }

        public static void SubscribeTo(int EventId, IEnumerable<int> EmpIds)
        {

        }

        public static IEnumerable<EmployeeEvent> GetSubscriptionStatus(int EventId)
        {

            return 
        }

        public static IEnumerable<EmployeeEvent> GetEmployeeSubscriptionStatus(int EventId,int EmpId)
        {

           return 
        }
    }
}
