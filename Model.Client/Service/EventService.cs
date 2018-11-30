using Model.Client.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;
using GD = Model.Global.Data;
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

            return GS.EventService.Create(Mappers.ToGlobal(e), UserId);
        }

        public static bool Edit(Event e, int UserId)
        {

            return GS.EventService.Edit(Mappers.ToGlobal(e), UserId);
        }

        public static bool Delete(Event e, int UserId)
        {

            return GS.EventService.Delete(Mappers.ToGlobal(e), UserId);
        }
        
        public static Event Get(int id)
        {

            return Mappers.ToClient(GS.EventService.Get(id));
        }

        public static IEnumerable<Event> GetAll()
        {
            List<Event> Events = new List<Event>();
            IEnumerable<GD.Event> GlobalEvents = GS.EventService.GetAll();
            foreach (GD.Event Event in GlobalEvents)
            {
                Events.Add(Mappers.ToClient(Event));
            }
            return Events;
        }

        public static IEnumerable<Event> GetAllActive()
        {
            List<Event> Events = new List<Event>();
            IEnumerable<GD.Event> GlobalEvents = GS.EventService.GetAllActive();
            foreach (GD.Event Event in GlobalEvents)
            {
                Events.Add(Mappers.ToClient(Event));
            }
            return Events;
        }

        public static IEnumerable<Event> GetAllActiveForUser(int UserId)
        {
            List<Event> Events = new List<Event>();
            IEnumerable<GD.Event> GlobalEvents = GS.EventService.GetAllActiveForUser(UserId);
            foreach (GD.Event Event in GlobalEvents)
            {
                Events.Add(Mappers.ToClient(Event));
            }
            return Events;
        }

        public static bool Participate(int EventId, int EmpId)
        {

            return GS.EventService.Participate(EventId, EmpId);
        }

         public static IEnumerable<EmployeeEvent> GetSubscriptionStatus(int EventId)
        {
            List<EmployeeEvent> EmployeeEvents = new List<EmployeeEvent>();
            IEnumerable<GD.EmployeeEvent> GlobalEmployeeEvents = GS.EventService.GetSubscriptionStatus(EventId);
            foreach (GD.EmployeeEvent EmployeeEvent in GlobalEmployeeEvents)
            {
                EmployeeEvents.Add(Mappers.ToClient(EmployeeEvent));
            }
            return EmployeeEvents;
        }

        public static IEnumerable<EmployeeEvent> GetEmployeeSubscriptionStatus(int EventId,int EmpId)
        {
            List<EmployeeEvent> EmployeeEvents = new List<EmployeeEvent>();
            IEnumerable<GD.EmployeeEvent> GlobalEmployeeEvents = GS.EventService.GetEmployeeSubscriptionStatus(EventId, EmpId);
            foreach (GD.EmployeeEvent EmployeeEvent in GlobalEmployeeEvents)
            {
                EmployeeEvents.Add(Mappers.ToClient(EmployeeEvent));
            }
            return EmployeeEvents;
        }
    }
}
